using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace EjercicioUno
{
    public partial class MainPage : ContentPage
    {
        string[] cedula = new string[8];
        string[] nombres = new string[8];
       // string[] cedulaNombre = new string[8];

        /* Datos
         *797-3244130-5   Juan Aldredo Perez Simo
         *473-409190-1    Eduardo Perez Rodriguez
         *808-4664631-7   Miguel Alberto Desangles Jimenez
         *254-2396982-3   Pedro Pablo Mateo Carbuccia
         *991-7171383-5   Angel Daniel Carrero Holguin
         *826-7152725-0   Samuel Cruz Medina
         *790-6652572-0   Rodolfo Perez
         *529-9038325-4   Laura Castellanos Vargas
          */
        public MainPage()
        {
            InitializeComponent();

        }
        private void BtnOdernarCedulas_Clicked(object sender, EventArgs e)
        {
            cedula[0] = "797-3244130-5";
            cedula[1] = "473-409190-1";
            cedula[2] = "808-4664631-7";
            cedula[3] = "254-2396982-3";
            cedula[4] = "991-7171383-5";
            cedula[5] = "826-7152725-0";
            cedula[6] = "790-6652572-0";
            cedula[7] = "529-9038325-4";
            int N = cedula.Length;
            for (int j = 0; j < N; j++)
            {
                cedula[j] = cedula[j].Replace("-", "");
            }
            //long sufix = 10;
            for (int j = 0; j < N; j++)
            {

                long newNum = Convert.ToInt64(cedula[j]);
                for (int i = j; i < N; i++)
                {
                    if (cedula[j] == cedula[i])
                    {
                        continue;
                    }
                    long sufix = 10;
                    while (newNum % sufix == Convert.ToInt64(cedula[i]) % sufix)
                    {

                        sufix *= 10;

                    }
                    if (newNum % sufix < Convert.ToInt64(cedula[i]) % sufix)
                    {
                        long temp = newNum;
                        cedula[j] = cedula[i];
                        cedula[i] = Convert.ToString(newNum);
                        newNum = Convert.ToInt64(cedula[j]);
                        sufix = 10;
                    }

                }

            }
            for (int i = 0; i < N; i++)
            {
                //DependencyService.Get<IToastMessage>().DisplayMessage(cedula[i]);

                var label = new Label { Text = cedula[i], TextColor = Color.FromHex("#77d065"), FontSize = 20 };
                layout.Children.Add(label);
                this.Content = layout;
            }
            btnOdernarCedulas.IsEnabled = false;
        }


        private void BtnGenerarCSV_Clicked(object sender, EventArgs e)
        {
            cedula[0] = "797-3244130-5";
            cedula[1] = "473-409190-1";
            cedula[2] = "808-4664631-7";
            cedula[3] = "254-2396982-3";
            cedula[4] = "991-7171383-5";
            cedula[5] = "826-7152725-0";
            cedula[6] = "790-6652572-0";
            cedula[7] = "529-9038325-4";

            nombres[2] = "Juan Aldredo Perez Simo";
            nombres[5] = " Eduardo Perez Rodriguez";
            nombres[0] = "Miguel Alberto Desangles Jimenez";
            nombres[4] = "Pedro Pablo Mateo Carbuccia";
            nombres[1] = "Angel Daniel Carrero Holguin";
            nombres[6] = "Samuel Cruz Medina";
            nombres[7] = "Rodolfo Perez";
            nombres[3] = "Laura Castellanos Vargas";
            int N = cedula.Length;
            for (int j = 0; j < N; j++)
            {
                cedula[j] = cedula[j].Replace("-", "");
            }
            //long sufix = 10;
            for (int j = 0; j < N; j++)
            {

                long newNum = Convert.ToInt64(cedula[j]);
                for (int i = j; i < N; i++)
                {
                    if (cedula[j] == cedula[i])
                    {
                        continue;
                    }
                    long sufix = 10;
                    while (newNum % sufix == Convert.ToInt64(cedula[i]) % sufix)
                    {

                        sufix *= 10;

                    }
                    if (newNum % sufix < Convert.ToInt64(cedula[i]) % sufix)
                    {
                        long temp = newNum;
                        cedula[j] = cedula[i];
                        cedula[i] = Convert.ToString(newNum);
                        newNum = Convert.ToInt64(cedula[j]);
                        sufix = 10;
                    }

                }

            }
            try
            {
               //Generando CSV
               
                var filename = Path.Combine("/sdcard", "cedulaOrdenada.csv");
                //StreamWriter stream = File.CreateText(filename);
                using (var file = new StreamWriter(File.Create(filename)))
                {
                    for (int i = 0; i < N; i++)
                    {
                        
                        file.WriteLine(nombres[i] + "," + cedula[i]);
                  
                    }

                }
                DependencyService.Get<IToastMessage>().DisplayMessage("CSV generado");
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }
    }
}
