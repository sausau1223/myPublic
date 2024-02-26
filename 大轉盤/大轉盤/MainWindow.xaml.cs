using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace 大轉盤
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        int 跑馬計數 = 1;
        int 上次位置 = 0;
        int 上上次位置 = 0;
        int 轉速 = 30;

        //string 轉向 = "逆轉";
        string 轉向 = "順轉";
        DispatcherTimer timer1 = new DispatcherTimer();

        //初始button
        Button 初始btn = new Button();


        void Window_Loaded(object sender, RoutedEventArgs e)
        {


            if (轉向 == "逆轉")
            {
                跑馬計數 = 1;
            }
            else
            {
                跑馬計數 = 1;
            }


            int x = 0;
            int y = 0;

            List<string> 餐廳名單 = new List<string>();

            if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour <= 23)
            {
                餐廳名單.Add("麥當勞");
                餐廳名單.Add("梁社漢");
                餐廳名單.Add("吉野家");
                餐廳名單.Add("爭鮮");
                餐廳名單.Add("八方雲集");
                餐廳名單.Add("自助餐");
                餐廳名單.Add("黃記魯肉飯");
                餐廳名單.Add("北投小籠包");
                餐廳名單.Add("三元號");
                餐廳名單.Add("三商巧福");
                餐廳名單.Add("石二鍋");
                餐廳名單.Add("炒飯炒麵");
                餐廳名單.Add("三媽臭臭鍋");
                餐廳名單.Add("關東煮壽司");
                餐廳名單.Add("燒臘");
                餐廳名單.Add("派克雞排");
                //餐廳名單.Add("麵線");
            }
            else
            {
                餐廳名單.Add("鮪魚御飯糰");
                餐廳名單.Add("雞肉御飯糰");
                餐廳名單.Add("和風海藻沙拉");
                餐廳名單.Add("萵苣沙拉");
                餐廳名單.Add("石安雙蛋三明治");
                餐廳名單.Add("蘑菇鐵板麵");
                餐廳名單.Add("阿義小籠包");
                餐廳名單.Add("可味肉包");
                餐廳名單.Add("老哥水煎包");
                餐廳名單.Add("麵線");
                餐廳名單.Add("涼麵");
                餐廳名單.Add("飯糰");
                餐廳名單.Add("地瓜");
                餐廳名單.Add("炒麵");
                餐廳名單.Add("大寶貝決定");
                餐廳名單.Add("漢堡");
            }


            //初始button
            Button 初始btn = new Button
            {
                Name = "初始btn",
                Background = Brushes.AliceBlue
            };

            


            for (int i = 1; i <= 16; i++)
            {
                if (i <= 5)
                {
                    x = (i - 1) * 80;
                }
                else if (i > 5 && i < 10)
                {
                    y = (i - 5) * 80;
                }
                else if (i >= 10 && i <= 13)
                {
                    x = 80 * (13 - i);
                }
                else if (i > 13)
                {
                    y = 80 * (17 - i);
                }


                Button btn = new Button
                {
                    Name = "Button" + i.ToString(),
                    Content = 餐廳名單[i - 1],
                    Height = 80,
                    Width = 80,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(x, y, 0, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                    Visibility = Visibility.Visible,
                    FontSize = 14,
                    Background = Brushes.AliceBlue
                };
                btn.Click += new RoutedEventHandler(btn_click);
                Grid_Main.Children.Add(btn);


                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = TimeSpan.FromSeconds(1);
                timer1.Interval = TimeSpan.FromMilliseconds(100);
                timer1.Start();
                timer1.IsEnabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (跑馬計數 == 1 && 轉向 == "逆轉")
            {
                timer1.Interval = TimeSpan.FromMilliseconds(0);
            }
            else if (跑馬計數 == 0 && 轉向 == "順轉")
            {
                timer1.Interval = TimeSpan.FromMilliseconds(0);
            }
            else
            {
                //轉速
                timer1.Interval = TimeSpan.FromMilliseconds(轉速);
            }

            if (轉向 == "逆轉")
            {
                UIUpdate逆轉();
            }
            else
            {
                UIUpdate順轉();
            }
        }

        


        private void Button_Click(object sender, RoutedEventArgs e)
        {


            

            if (Button_Start.Content.ToString() == "啟動")
            {
                timer1.IsEnabled = true;
                Button_Start.Content = "停止";
            }
            else
            {
                timer1.IsEnabled = false;
                Button_Start.Content = "啟動";
                try
                {
                    Random 亂數產生器 = new Random();
                    int 尋找目標 = 亂數產生器.Next(1, 16);
                    Button btn = new Button();

                    //清空按鈕顏色
                    for (int i = 0; i < Grid_Main.Children.Count; i++)
                    {
                        btn = (Button)Grid_Main.Children[i];
                        //btn.Background = Button_Start.Background;
                        btn.Background = 初始btn.Background;
                        btn.Background = Brushes.AliceBlue;
                    }


                    for (int i = 0; i < Grid_Main.Children.Count; i++)
                    {
                        if (尋找目標 == i)
                        {
                            btn = (Button)Grid_Main.Children[i];
                            btn.Background = Brushes.Green;
                            //break;


                            MessageBox.Show(btn.Content.ToString());
                        }
                        else
                        {
                            btn = (Button)Grid_Main.Children[i];
                            //btn.Background = Button_Start.Background;
                            btn.Background = 初始btn.Background;
                            btn.Background = Brushes.AliceBlue;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }



         

        }

        private void btn_click(object sender, RoutedEventArgs e)
        {


        }


        private void UIUpdate順轉()
        {

            Button btn = new Button();


            上次位置 = 跑馬計數 + 1;
            上上次位置 = 上次位置 + 1;

            int 尋找目標 = 跑馬計數;

            if (跑馬計數 == 0)
            {
                尋找目標 = 16;
                跑馬計數 = 17;
            }
            else if (上次位置 == 17)
            {
                上次位置 = 1;
                上上次位置 = 2;
            }
            else if (上上次位置 == 17)
            {
                上上次位置 = 1;
            }
            

 

            //清空按鈕顏色
            for (int i = 0; i < Grid_Main.Children.Count; i++)
            {
                btn = (Button)Grid_Main.Children[i];
                //btn.Background = Button_Start.Background;
                //btn.Background = Brushes.LightSteelBlue;
                btn.Background = Brushes.AliceBlue;
                //btn.Background = 初始btn.Background;
            }

            //btn = (Button)Grid_Main.Children[尋找目標];
            //btn.Background = Brushes.Green;

            //btn = (Button)Grid_Main.Children[上次位置];
            //btn.Background = Brushes.LawnGreen;

     

   

            btn = (Button)Grid_Main.Children[尋找目標];
            btn.Background = Brushes.MediumSpringGreen;
            btn.Background = Brushes.MediumSeaGreen;
            btn.Background = new SolidColorBrush(Color.FromRgb(28, 255, 92));
            btn.Background = new SolidColorBrush(Color.FromRgb(5, 210, 70));


            btn = (Button)Grid_Main.Children[上次位置];
            btn.Background = Brushes.MediumSeaGreen;
            btn.Background = new SolidColorBrush(Color.FromRgb(0, 163, 70));
            //btn.Background = Brushes.LimeGreen;

            btn = (Button)Grid_Main.Children[上上次位置];
            btn.Background = Brushes.Green;



            跑馬計數--;

        }




        private void UIUpdate逆轉()
        {

            Button btn = new Button();


            上次位置 = 跑馬計數-1;

            int 尋找目標 = 跑馬計數;
            
            if (跑馬計數 >= 17)
            {
                尋找目標 = 1;
                跑馬計數 = 0;
            }

            //清空按鈕顏色
            for (int i = 0; i < Grid_Main.Children.Count; i++)
            {
                btn = (Button)Grid_Main.Children[i];
                //btn.Background = Button_Start.Background;
                btn.Background = 初始btn.Background;
            }

            btn = (Button)Grid_Main.Children[尋找目標];
            btn.Background = Brushes.Green;

            跑馬計數++;

        }


    }



}
