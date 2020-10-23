using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace DJI___App1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public string FolderPath;


        public class DTS_Image
        {
            // File Info
            public string Name;
            public string SourceFilePath;

            // Thermal Parameters
            public string Palette = "iron_red";
            public double Scale_High = -100;
            public double Scale_Low = -100;
            public double Emissivity = 1;
            public double T_Refl = 25;
            public double Distance = 10;
            public double Humidity = 50;

            // Updated Values
            public double[,] TempMap;
            public Bitmap IMG;
            public Bitmap PalBar;

            // Methods
            public string Generate_Arg_Measure(string Input, string Output)
            {
                string Arg = $"-s {Input} -a measure -o {Output} --measure_format float32 --emissivity {Emissivity} --reflection {T_Refl} --distance {Distance} --humidity {Humidity}";
                return Arg;
            }
            public string Generate_Arg_Process(string Input, string Output)
            {
                string ARG;
                if ((Palette == "white_hot") || (Palette == "fulgurite") || (Palette == "iron_red")
                    || (Palette == "hot_iron") || (Palette == "medical") || (Palette == "arctic")
                    || (Palette == "rainbow1") || (Palette == "rainbow2") || (Palette == "tint")
                    || (Palette == "black_hot"))   // these conditions are the only acceptable values for the Palette
                {
                    if ((Scale_High == -100) && (Scale_Low == -100))
                    {   // meaning that Scale values have not been updated 
                        ARG = $"-s {Input} -a process -o {Output} --palette {Palette}";
                    }
                    else if (Scale_High > Scale_Low)
                    {
                        ARG = $"-s {Input} -a process -o {Output} --palette {Palette} --colorbar on,{Scale_High},{Scale_Low}";
                    }
                    else
                    {
                        ARG = "ERROR - Scale values incorrect";
                    }
                }
                else
                {
                    ARG = "ERROR - Palette value incorrect";
                }
                return ARG;

            }
            public double[,] Raw2TempMap(string Input)
            {
                double[,] TempMap = new double[640, 512];   // Empty TempMap 2D array 

                if (File.Exists(Input))
                {
                    MemoryStream memoryStream = new MemoryStream(1000000);
                    FileStream fs = new FileStream(Input, FileMode.Open);
                    fs.CopyTo(memoryStream);
                    byte[] buffer = memoryStream.ToArray();
                    fs.Close(); // Close the fs 

                    int TempTau = 640 * 4;
                    for (int R = 0; R < 512; R++)
                    {
                        byte[] Row = new byte[TempTau];
                        Array.Copy(buffer, R * TempTau, Row, 0, TempTau);

                        for (int C = 0; C < TempTau; C = C + 4)     // Iterate through all bytes of the row in steps of 4
                        {   // C: coloumn number 
                            byte[] SingleTmp = new byte[4];
                            Array.Copy(Row, C, SingleTmp, 0, 4);
                            double TempMeasurement = BitConverter.ToSingle(SingleTmp, 0);
                            TempMap[C / 4, R] = TempMeasurement;
                        }
                    }
                }
                return TempMap;
            }
            public void Raw2Bitmap(string RawPath, out Bitmap IMG)
            {
                Bitmap bmp = new Bitmap(640, 512);  // Blank Bitmap 

                if (File.Exists(RawPath))
                {
                    // Create the Memory Stream to read the bytes;
                    MemoryStream memoryStream = new MemoryStream(1000000);
                    FileStream fs = new FileStream(RawPath, FileMode.Open);
                    fs.CopyTo(memoryStream);
                    byte[] buffer = memoryStream.ToArray();
                    fs.Close(); // Close the fs 

                    int Tau = 640 * 3;                  // Tau = number of bytes in each row 

                    for (int R = 0; R < 512; R++)       // Go through all rows (R: row number
                    {
                        byte[] Row = new byte[Tau];     // bytes for each row
                        Array.Copy(buffer, R * Tau, Row, 0, Tau);
                        for (int C = 0; C < Tau; C = C + 3)     // Iterate through all bytes of the row in steps of 3
                        {   // C: coloumn number 
                            int Red, Green, Blue;
                            Red = Row[C];
                            Green = Row[C + 1];
                            Blue = Row[C + 2];
                            Color PixelColor = Color.FromArgb(255, Red, Green, Blue);     // Generate color of pixel
                            bmp.SetPixel(C / 3, R, PixelColor);
                        }
                    }
                }
                IMG = bmp;
            }
            // public void Generate_PalBar(Bitmap IMG, double[,] TempMap)   // To be developed
            

            
            // Update Method
            public void Update()
            {
                // Temperory file which is to be processed
                string LocalInput = @"Files\Assets\LocalInput.jpg";
                if (File.Exists(LocalInput))
                    File.Delete(LocalInput);

                File.Copy(SourceFilePath, LocalInput, true);

                
                // Temp output files (measure/process)
                string MeasureOutputFile = @"Files\Assets\measure.raw";
                if (File.Exists(MeasureOutputFile))
                    File.Delete(MeasureOutputFile);

                string ProcessOutputFile = @"Files\Assets\process.raw";
                if (File.Exists(ProcessOutputFile))
                    File.Delete(ProcessOutputFile);

                PerformFunc("irp", 'M', LocalInput, MeasureOutputFile);
                PerformFunc("irp", 'P', LocalInput, ProcessOutputFile);


                // Fill up the DTS_Image instance 
                TempMap = Raw2TempMap(MeasureOutputFile);
                Raw2Bitmap(ProcessOutputFile, out IMG);
            }
            

            ///<summary>
            /// CMD can be one of the following options: "irp", "irp_omp", "ircm".
            /// Mode can only take 'M' or 'P' for "Measure" and "Process" functions respectively.
            ///</summary>
            public void PerformFunc(string CMD, char Mode, string Input, string Output)
            {
                string Arg = "";
                if (Mode.Equals('M') || Mode.Equals('m'))
                {
                    Arg = Generate_Arg_Measure(Input, Output);
                    //Console.WriteLine(Arg);     //DEBUG
                }
                if (Mode.Equals('P') || Mode.Equals('p'))
                {
                    Arg = Generate_Arg_Process(Input, Output);
                    //Console.WriteLine(Arg);     //DEBUG
                }


                string path = Directory.GetCurrentDirectory() + "\\Files\\Functions";
                string command = path + "\\dji_irp.exe"; //DEFAULT 
                if (CMD == "irp")
                    command = path + "\\dji_irp.exe";
                if (CMD == "irp_omp")
                    command = path + "\\dji_irp_omp.exe";
                if (CMD == "ircm")
                    command = path + "\\dji_ircm.exe";

                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = command;
                pProcess.StartInfo.Arguments = Arg;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.Start();
                string strOutput = pProcess.StandardOutput.ReadToEnd();
                pProcess.WaitForExit();         // DJI Command done
            
            }

        }

        public List<DTS_Image> Images_List = new List<DTS_Image>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            Images_List.Clear();
            listBox1.Items.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Open the folder containing Thermal images";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderPath = fbd.SelectedPath;

                string[] files = Directory.GetFiles(FolderPath);

                foreach (string file in files)
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                    Add_DTS_Image(file);
                }
            }

            listBox1.SelectedIndex = 0;

        }

        public void Add_DTS_Image(string FilePath)
        {
            DTS_Image dTS_Image = new DTS_Image();

            dTS_Image.Name = Path.GetFileName(FilePath);
            dTS_Image.SourceFilePath = FilePath;

            dTS_Image.Update();

            Images_List.Add(dTS_Image);

        }

        private void Button_ApplyDisplay_Click(object sender, EventArgs e)
        {
            string SelectedItemName = listBox1.Items[listBox1.SelectedIndex].ToString();
            // Use the line below to find the selected image
            // Images_List.Find(K => K.Name == SelectedItemName).[whatever attribute]
            double Scale_High = 0, Scale_Low = 0, Emissivity=-100, T_Refl=-100, Distance=-100, Humidity=-100;

            string pal_sel = Convert.ToString(dropdown_pal.SelectedItem);
            if (!string.IsNullOrWhiteSpace(Textbox_ScaleHigh.Text))
                Scale_High = Convert.ToDouble(Textbox_ScaleHigh.Text);

            if (!string.IsNullOrWhiteSpace(Textbox_ScaleLow.Text))
                Scale_Low = Convert.ToDouble(Textbox_ScaleLow.Text);

            if (!string.IsNullOrWhiteSpace(Textbox_Emissivity.Text))
                Emissivity = Convert.ToDouble(Textbox_Emissivity.Text);

            if (!string.IsNullOrWhiteSpace(Textbox_ReflTemp.Text))
                T_Refl = Convert.ToDouble(Textbox_ReflTemp.Text);

            if (!string.IsNullOrWhiteSpace(Textbox_Distance.Text))
                Distance = Convert.ToDouble(Textbox_Distance.Text);

            if (!string.IsNullOrWhiteSpace(Textbox_Emissivity.Text))
                Humidity = Convert.ToDouble(Textbox_Emissivity.Text);

            // Update Palette
            string Pal_CMD = "iron_red"; //default

            switch (pal_sel)
            {
                case "Iron Red":
                    Pal_CMD = "iron_red";
                    break;
                case "Hot Iron":
                    Pal_CMD = "hot_iron";
                    break;
                case "Fulgurite":
                    Pal_CMD = "fulgurite";
                    break;
                case "Medical":
                    Pal_CMD = "medical";
                    break;
                case "Arctic":
                    Pal_CMD = "arctic";
                    break;
                case "Rainbow 1":
                    Pal_CMD = "rainbow1";
                    break;
                case "Rainbow 2":
                    Pal_CMD = "rainbow2";
                    break;
                case "White Hot":
                    Pal_CMD = "white_hot";
                    break;
                case "Black Hot":
                    Pal_CMD = "black_hot";
                    break;
                case "Tint":
                    Pal_CMD = "tint";
                    break;
            }
            Images_List.Find(K => K.Name == SelectedItemName).Palette = Pal_CMD;

            // Update Scale
            if (Scale_High > Scale_Low)
            {
                Images_List.Find(K => K.Name == SelectedItemName).Scale_High = Scale_High;
                Images_List.Find(K => K.Name == SelectedItemName).Scale_Low = Scale_Low;
            }

            //Update Thermal Parameters
            if (Emissivity >= 0.1 && Emissivity <= 1)
                Images_List.Find(K => K.Name == SelectedItemName).Emissivity = Emissivity;

            if (T_Refl >= -40 && T_Refl <= 500)
                Images_List.Find(K => K.Name == SelectedItemName).T_Refl = T_Refl;

            if (Distance >= 1 && Distance <= 25)
                Images_List.Find(K => K.Name == SelectedItemName).Distance = Distance;

            if (Humidity >= 20 && Humidity <= 100)
                Images_List.Find(K => K.Name == SelectedItemName).Humidity = Humidity;

            // Update and Display
            Images_List.Find(K => K.Name == SelectedItemName).Update();
            DisplayImage();

        }

        public void DisplayImage()
        {
            string SelectedItemName = listBox1.Items[listBox1.SelectedIndex].ToString();
            pictureBox1.Image = Images_List.Find(K => K.Name == SelectedItemName).IMG;
        }

        private void Textbox_ScaleHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayImage();
        }


        private void debug_Click(object sender, EventArgs e)
        {
            // Generate PalBar
            /*
             * There are different sections to this project
             * Find the Highest low-temp value for the bottom of the bar    Lets Not    
             * Find the lowest high-temp value for the top of the bar       Lets Not
             * Divide everything in between to 0.1 C steps 
             * Generate the empty bitmap based on the acquired scale
             * 
             * 
             * 
             * 
             * 
             * 
             */

            DTS_Image dTS_Image = new DTS_Image();
            dTS_Image = Images_List[0];
            double[,] TempMap = dTS_Image.TempMap;
            double Min, Max;
            FindMinMax(dTS_Image.TempMap, out Min, out Max);

            // If Scale has not been set yet:
            double Steps = (Max - Min) / 0.1;
            
            //Bitmap PalBar 



            // If Scale has been manually set:





        }

        public void FindValueIndex(double[,] TempMap, double Value, out double Index1, out double Index2)
        {
            Index1 = -1;
            Index2 = -1;

            double Dim1 = TempMap.GetLength(0);
            double Dim2 = TempMap.GetLength(1);

            for (int i = 0; i < Dim1; i++)
            {
                for (int j = 0; j < Dim2; j++)
                {
                    if (TempMap[i, j] == Value)
                    {
                        Index1 = i;
                        Index2 = j;
                        break;
                    }
                }
            }


        }

        public void FindMinMax(double[,] TempMap, out double Min, out double Max)
        {
            Min = 500;
            Max = -100;
            double Dim1 = TempMap.GetLength(0);
            double Dim2 = TempMap.GetLength(1);

            for (int i=0; i < Dim1; i++)
            {
                for (int j = 0; j < Dim2; j++)
                {
                    if (TempMap[i, j] > Max)
                        Max = TempMap[i, j];
                    if (TempMap[i, j] < Min)
                        Min = TempMap[i, j];
                }
            }
        }




        // ---------------------------------------- Functions - May be Legacy -------------------------------


        public void DJIFunc(string DJI_EXE, string ARG)
        {
            string path = Directory.GetCurrentDirectory() + "\\Files\\Functions";
            string command = path + "\\dji_irp.exe"; //DEFAULT 
            if (DJI_EXE == "irp")
                command = path + "\\dji_irp.exe";
            if (DJI_EXE == "irp_omp")
                command = path + "\\dji_irp_omp.exe";
            if (DJI_EXE == "ircm")
                command = path + "\\dji_ircm.exe";

            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = command;
            pProcess.StartInfo.Arguments = ARG;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            pProcess.WaitForExit();         // DJI Command done
        }

        public void DisplayImage(string Input, out Bitmap IMG)
        {
            // input is the image itself
            // output is the image 


            string output = "display.raw";
            string palette = "iron_red";
            string ARG = "-s " + Input + " -a process -o " + output + " --palette " + palette/* + " --colorbar on -10 -25"*/;
            string command = "irp";
            DJIFunc(command, ARG);
            Bitmap bmp = new Bitmap(640, 512);  // Blank Bitmap 

            if (File.Exists(output))
            {
                // Create the Memory Stream to read the bytes;
                MemoryStream memoryStream = new MemoryStream(1000000);
                FileStream fs = new FileStream(output, FileMode.Open);
                fs.CopyTo(memoryStream);
                byte[] buffer = memoryStream.ToArray();
                fs.Close(); // Close the fs 

                int Tau = 640 * 3;                  // Tau = number of bytes in each row 

                for (int R = 0; R < 512; R++)       // Go through all rows (R: row number
                {
                    byte[] Row = new byte[Tau];     // bytes for each row
                    Array.Copy(buffer, R * Tau, Row, 0, Tau);
                    for (int C = 0; C < Tau; C = C + 3)     // Iterate through all bytes of the row in steps of 3
                    {   // C: coloumn number 
                        int Red, Green, Blue;
                        Red = Row[C];
                        Green = Row[C + 1];
                        Blue = Row[C + 2];
                        Color PixelColor = Color.FromArgb(255, Red, Green, Blue);     // Generate color of pixel
                        bmp.SetPixel(C / 3, R, PixelColor);
                    }
                }

            }
            IMG = bmp;
        }

        public double[,] GetTempMap(string Input)
        {
            // Input is the image 
            // Output is the TempMap array 

            double[,] TempMap = new double[640, 512];   // Empty TempMap 2D array 

            if (File.Exists(Input))
            {
                string output = "TempMap_Measure.raw";
                string ARG = $"-s {Input} -a measure -o {output} --measure_format float32 --emissivity 0.95";
                string command = "irp";
                DJIFunc(command, ARG);

                // Create the Memory Stream to read the bytes;
                MemoryStream memoryStream = new MemoryStream(1000000);
                FileStream fs = new FileStream(output, FileMode.Open);
                fs.CopyTo(memoryStream);
                byte[] buffer = memoryStream.ToArray();
                fs.Close(); // Close the fs 

                int TempTau = 640 * 4;

                for (int R = 0; R < 512; R++)       // Go through all rows (R: row number)
                {
                    byte[] Row = new byte[TempTau];     // bytes for each row
                    Array.Copy(buffer, R * TempTau, Row, 0, TempTau);

                    for (int C = 0; C < TempTau; C = C + 4)     // Iterate through all bytes of the row in steps of 4
                    {   // C: coloumn number 
                        byte[] SingleTmp = new byte[4];
                        Array.Copy(Row, C, SingleTmp, 0, 4);
                        double TempMeasurement = BitConverter.ToSingle(SingleTmp, 0);
                        TempMap[C / 4, R] = TempMeasurement;
                    }
                }
            }
            return TempMap;
        }

        public double[,] GetTempMapFromRaw(string Input)
        {
            double[,] TempMap = new double[640, 512];   // Empty TempMap 2D array 

            if (File.Exists(Input))
            {
                MemoryStream memoryStream = new MemoryStream(1000000);
                FileStream fs = new FileStream(Input, FileMode.Open);
                fs.CopyTo(memoryStream);
                byte[] buffer = memoryStream.ToArray();
                fs.Close(); // Close the fs 

                int TempTau = 640 * 4;
                for (int R = 0; R < 512; R++)
                {
                    byte[] Row = new byte[TempTau];
                    Array.Copy(buffer, R * TempTau, Row, 0, TempTau);

                    for (int C = 0; C < TempTau; C = C + 4)     // Iterate through all bytes of the row in steps of 4
                    {   // C: coloumn number 
                        byte[] SingleTmp = new byte[4];
                        Array.Copy(Row, C, SingleTmp, 0, 4);
                        double TempMeasurement = BitConverter.ToSingle(SingleTmp, 0);
                        TempMap[C / 4, R] = TempMeasurement;
                    }
                }
            }
            return TempMap;
        }



        // Further Funcs
        public void DisplayFromRaw(string RawPath, out Bitmap IMG)
        {
            Bitmap bmp = new Bitmap(640, 512);  // Blank Bitmap 

            if (File.Exists(RawPath))
            {
                // Create the Memory Stream to read the bytes;
                MemoryStream memoryStream = new MemoryStream(1000000);
                FileStream fs = new FileStream(RawPath, FileMode.Open);
                fs.CopyTo(memoryStream);
                byte[] buffer = memoryStream.ToArray();
                fs.Close(); // Close the fs 

                int Tau = 640 * 3;                  // Tau = number of bytes in each row 

                for (int R = 0; R < 512; R++)       // Go through all rows (R: row number
                {
                    byte[] Row = new byte[Tau];     // bytes for each row
                    Array.Copy(buffer, R * Tau, Row, 0, Tau);
                    for (int C = 0; C < Tau; C = C + 3)     // Iterate through all bytes of the row in steps of 3
                    {   // C: coloumn number 
                        int Red, Green, Blue;
                        Red = Row[C];
                        Green = Row[C + 1];
                        Blue = Row[C + 2];
                        Color PixelColor = Color.FromArgb(255, Red, Green, Blue);     // Generate color of pixel
                        bmp.SetPixel(C / 3, R, PixelColor);
                    }
                }
            }
            IMG = bmp;
        }

        public void DisplayFromRaw_DEBUG(string RawPath, int width, int height, out Bitmap IMG)
        {

            Bitmap bmp = new Bitmap(width, height);  // Blank Bitmap 

            if (File.Exists(RawPath))
            {
                // Create the Memory Stream to read the bytes;
                MemoryStream memoryStream = new MemoryStream(1000000);
                FileStream fs = new FileStream(RawPath, FileMode.Open);
                fs.CopyTo(memoryStream);
                byte[] buffer = memoryStream.ToArray();
                fs.Close(); // Close the fs 

                int Tau = width * 3;                  // Tau = number of bytes in each row 

                for (int R = 0; R < height; R++)       // Go through all rows (R: row number)
                {
                    byte[] Row = new byte[Tau];     // bytes for each row
                    Array.Copy(buffer, R * Tau, Row, 0, Tau);
                    for (int C = 0; C < Tau; C = C + 3)     // Iterate through all bytes of the row in steps of 3
                    {   // C: coloumn number 
                        int Red, Green, Blue;
                        Red = Row[C];
                        Green = Row[C + 1];
                        Blue = Row[C + 2];
                        Color PixelColor = Color.FromArgb(255, Red, Green, Blue);     // Generate color of pixel
                        bmp.SetPixel(C / 3, R, PixelColor);
                    }
                }
            }
            IMG = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}


