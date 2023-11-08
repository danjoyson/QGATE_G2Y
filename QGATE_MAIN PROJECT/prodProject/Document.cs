using Spire.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
namespace prodProject
{
    internal class Document
    {
        string imagesPath = Application.StartupPath + @"\images\";

        public  bool PptxToImage(string path, string partName)
        {
            imagesPath = imagesPath + partName + @"\";
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(imagesPath);
                // Iniciar una aplicación PowerPoint
                Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();

                // Abrir la presentación
                Microsoft.Office.Interop.PowerPoint.Presentation pptPresentation = pptApplication.Presentations.Open(path, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);

                // Recorrer las diapositivas y guardarlas como imágenes
                for (int i = 1; i <= pptPresentation.Slides.Count; i++)
                {
                    // Obtener la diapositiva actual
                    Microsoft.Office.Interop.PowerPoint.Slide slide = pptPresentation.Slides[i];

                    // Ruta donde guardar la imagen
                    string imagePath = string.Format(imagesPath+partName + "_S{0}.JPG", i-1);

                    // Guardar la diapositiva como imagen JPG
                    //MessageBox.Show(imagePath);
                    slide.Export(imagePath, "JPG", 1280, 720);
                }

                // Cerrar la presentación y salir de PowerPoint
                pptPresentation.Close();
                pptApplication.Quit();

                MessageBox.Show("Diapositivas convertidas en imágenes.");
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public string getPath()
        {
            var filePath = string.Empty;
            string fileDir;
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Power Point Files (*.pptx)|*.pptx";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
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
