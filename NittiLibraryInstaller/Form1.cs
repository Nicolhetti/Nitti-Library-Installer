using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NittiLibraryInstaller
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> libraries;
        private Dictionary<string, string> libraryDescriptions;

        public Form1()
        {
            InitializeComponent();
            libraries = new Dictionary<string, string>
            {
                { "DirectX (WEB)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/DirectX/dxwebsetup.exe" },
                { "Microsoft Visual C++ Redistributable 2005 (x86)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2005/vcredist_2005_x86.EXE" },
                { "Microsoft Visual C++ Redistributable 2005 (x64)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2005/vcredist_2005_x64.EXE" },
                { "Microsoft Visual C++ Redistributable 2008 (x86)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2008/vcredist_2008_x86.exe" },
                { "Microsoft Visual C++ Redistributable 2008 (x64)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2008/vcredist_2008_x64.exe" },
                { "Microsoft Visual C++ Redistributable 2010 (x86)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2010/vcredist_2010_x86.exe" },
                { "Microsoft Visual C++ Redistributable 2010 (x64)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2010/vcredist_2010_x64.exe" },
                { "Microsoft Visual C++ Redistributable 2012 (x86)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2012/vcredist_2012_x86.exe" },
                { "Microsoft Visual C++ Redistributable 2012 (x64)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2012/vcredist_2012_x64.exe" },
                { "Microsoft Visual C++ Redistributable 2013 (x86)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2013/vcredist_2013_x86.exe" },
                { "Microsoft Visual C++ Redistributable 2013 (x64)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2013/vcredist_2013_x64.exe" },
                { "Microsoft Visual C++ Redistributable 2015, 2017, 2019 y 2022 (x86)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2015%2C%202017%2C%202019%20y%202022/vcredist_2015_2017_2019_2022_x86.exe" },
                { "Microsoft Visual C++ Redistributable 2015, 2017, 2019 y 2022 (x64)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20Visual%20C%2B%2B%20Redistributable/2015%2C%202017%2C%202019%20y%202022/vcredist_2015_2017_2019_2022_x64.exe" },
                { "Microsoft XNA Framework Redistributable 4.0", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/Microsoft%20XNA%20Framework%20Redistributable%204.0/xnafx40_redist.msi" },
                { ".NET Framework 3.5 SP1", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/NET%20Framework/.NET%20Framework%203.5%20SP1/dotnetfx35.exe" },
                { ".NET Framework 4.6.2 (WEB)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/NET%20Framework/.NET%20Framework%204.6.2/ndp462-kb3151802-web.exe" },
                { ".NET Framework 4.7.1 (WEB)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/NET%20Framework/.NET%20Framework%204.7.1/ndp471-kb4033344-web.exe" },
                { ".NET Framework 4.7.2 (WEB)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/NET%20Framework/.NET%20Framework%204.7.2/ndp472-kb4054531-web.exe" },
                { ".NET Framework 4.7 (WEB)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/NET%20Framework/.NET%20Framework%204.7/ndp47-kb3186500-web.exe" },
                { ".NET Framework 4.8.1 (WEB)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/NET%20Framework/.NET%20Framework%204.8.1/NDP481-Web.exe" },
                { ".NET Framework 4.8 (WEB)", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/NET%20Framework/.NET%20Framework%204.8/ndp48-web.exe" },
                { "OpenAL", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/OpenAL/oalinst.exe" },
                { "PhysX System Software 9.16.0318", "https://huggingface.co/spaces/Nicolhetti-Projects/Nicolhetti-Archives/resolve/main/Pack%20de%20Librerias%20BPG/PhysX%20System%20Software%209.16.0318/PhysX-9.16.0318-SystemSoftware.exe" }
            };
            libraryDescriptions = new Dictionary<string, string>
            {
                { "DirectX (WEB)", "DirectX es una colección de interfaces de programación de aplicaciones (APIs) desarrollada por Microsoft para manejar tareas relacionadas con multimedia, especialmente juegos y videos. Incluye bibliotecas para gráficos 2D y 3D, procesamiento de audio, y entrada/salida de dispositivos. Es esencial para que muchos juegos funcionen correctamente en sistemas Windows." },
                { "Microsoft Visual C++ Redistributable 2005 (x86)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2005 (x64)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2008 (x86)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2008 (x64)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2010 (x86)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2010 (x64)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2012 (x86)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2012 (x64)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2013 (x86)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2013 (x64)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2015, 2017, 2019 y 2022 (x86)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft Visual C++ Redistributable 2015, 2017, 2019 y 2022 (x64)", "Microsoft Visual C++ Redistributable es un conjunto de bibliotecas en tiempo de ejecución necesarias para ejecutar aplicaciones desarrolladas con Microsoft Visual C++. Estas bibliotecas incluyen rutinas de uso común que muchas aplicaciones y juegos requieren para funcionar, por lo que su instalación es crucial para evitar errores de ejecución." },
                { "Microsoft XNA Framework Redistributable 4.0", "Microsoft XNA Framework Redistributable es un conjunto de herramientas con un entorno de ejecución administrado que facilita el desarrollo de videojuegos para PC, Xbox y Windows Phone. Proporciona APIs para el manejo de gráficos, sonidos, entrada de usuario, y más, simplificando el desarrollo de juegos en plataformas Microsoft." },
                { ".NET Framework 3.5 SP1", "NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno controlado en el que las aplicaciones pueden ser desarrolladas y ejecutadas. Incluye una gran biblioteca de clases y soporte para varios lenguajes de programación. Muchos juegos y aplicaciones requieren .NET Framework para funcionar correctamente." },
                { ".NET Framework 4.6.2 (WEB)", "NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno controlado en el que las aplicaciones pueden ser desarrolladas y ejecutadas. Incluye una gran biblioteca de clases y soporte para varios lenguajes de programación. Muchos juegos y aplicaciones requieren .NET Framework para funcionar correctamente." },
                { ".NET Framework 4.7.1 (WEB)", "NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno controlado en el que las aplicaciones pueden ser desarrolladas y ejecutadas. Incluye una gran biblioteca de clases y soporte para varios lenguajes de programación. Muchos juegos y aplicaciones requieren .NET Framework para funcionar correctamente." },
                { ".NET Framework 4.7.2 (WEB)", "NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno controlado en el que las aplicaciones pueden ser desarrolladas y ejecutadas. Incluye una gran biblioteca de clases y soporte para varios lenguajes de programación. Muchos juegos y aplicaciones requieren .NET Framework para funcionar correctamente." },
                { ".NET Framework 4.7 (WEB)", "NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno controlado en el que las aplicaciones pueden ser desarrolladas y ejecutadas. Incluye una gran biblioteca de clases y soporte para varios lenguajes de programación. Muchos juegos y aplicaciones requieren .NET Framework para funcionar correctamente." },
                { ".NET Framework 4.8.1 (WEB)", "NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno controlado en el que las aplicaciones pueden ser desarrolladas y ejecutadas. Incluye una gran biblioteca de clases y soporte para varios lenguajes de programación. Muchos juegos y aplicaciones requieren .NET Framework para funcionar correctamente." },
                { ".NET Framework 4.8 (WEB)", "NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno controlado en el que las aplicaciones pueden ser desarrolladas y ejecutadas. Incluye una gran biblioteca de clases y soporte para varios lenguajes de programación. Muchos juegos y aplicaciones requieren .NET Framework para funcionar correctamente." },
                { "OpenAL", "OpenAL (Open Audio Library) es una API multiplataforma diseñada para proporcionar una interfaz estándar para la reproducción de audio tridimensional. Es utilizada por muchos juegos para gestionar el sonido envolvente, efectos de sonido y posicionamiento de audio en un espacio 3D." },
                { "PhysX System Software 9.16.0318", "PhysX System Software es un motor de física desarrollado por NVIDIA que proporciona simulaciones realistas de dinámicas físicas en videojuegos. PhysX se encarga de calcular efectos como colisiones, explosiones, y movimientos de objetos, permitiendo una experiencia de juego más inmersiva." }
            };
            InitializeCheckBoxes();
        }

        private void InitializeCheckBoxes()
        {
            foreach (var library in libraries)
            {
                checkedListBoxLibraries.Items.Add(library.Key);
            }
        }

        private async void buttonInstall_Click(object sender, EventArgs e)
        {
            buttonInstall.Enabled = false;
            foreach (string library in checkedListBoxLibraries.CheckedItems)
            {
                string url = libraries[library];
                await DownloadAndInstallLibrary(library, url);
            }
            MessageBox.Show("¡Todas las librerías seleccionadas se han instalado correctamente!", "Instalación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buttonInstall.Enabled = true;
        }

        private async Task DownloadAndInstallLibrary(string libraryName, string url)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(url));
            using (WebClient client = new WebClient())
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                labelStatus.Text = $"Descargando {libraryName}...";
                client.DownloadProgressChanged += (s, e) =>
                {
                    progressBar1.Value = e.ProgressPercentage;
                };
                await client.DownloadFileTaskAsync(new Uri(url), tempFilePath);
                labelStatus.Text = $"Instalando {libraryName}...";
                Process.Start(tempFilePath).WaitForExit();
                labelStatus.Text = $"{libraryName} instalado.";
            }
        }

        private void checkedListBoxLibraries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxLibraries.SelectedItem != null)
            {
                string selectedLibrary = checkedListBoxLibraries.SelectedItem.ToString();
                labelInfo.Text = libraryDescriptions[selectedLibrary];

                if (!panelInfo.Visible)
                {
                    this.ClientSize = new System.Drawing.Size(567, 300);
                    panelInfo.Visible = true;
                }
            }
        }

        private void buttonDeleteTempFiles_Click(object sender, EventArgs e)
        {
            string tempPath = Path.GetTempPath();
            DirectoryInfo tempDir = new DirectoryInfo(tempPath);

            foreach (FileInfo file in tempDir.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"No se pudo borrar el archivo {file.Name}: {ex.Message}");
                }
            }

            MessageBox.Show("Archivos temporales eliminados (excepto aquellos que no se pudieron eliminar).", "Operación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
