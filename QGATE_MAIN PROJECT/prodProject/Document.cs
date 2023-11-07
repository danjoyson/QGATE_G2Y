using Spire.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace prodProject
{
    internal class Document
    {
        
        public bool PptxToImages(string path)
        {
            Presentation presentation = new Presentation();

            //Load a PowerPoint document
            try
            {
                presentation.LoadFromFile(path);
                int i = 0;
                //Iterate through all slides in the PowerPoint document
                foreach (ISlide slide in presentation.Slides)
                {
                    //Save each slide as PNG image

                    Image image = slide.SaveAsImage();
                    string fileName = string.Format(path, i);
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    i++;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public string getPath()
        {
            var filePath = string.Empty;

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.pptx)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        //var fileStream = openFileDialog.OpenFile();
                        //file = System.IO.Path.GetFileName(filePath);
                        //filedir = System.IO.Path.GetDirectoryName(filePath);
                        //MessageBox.Show(filedir);
                        return filePath;
                    }
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return filePath;
            }

        }


    }
}
