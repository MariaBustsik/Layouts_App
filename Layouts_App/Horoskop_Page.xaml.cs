using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Horoskop_Page : ContentPage


    {
        Entry zodiacEntry;
        Picker chooseZodiacSign;
        DatePicker zodiacDatePicker;
        Image zodiacImage;
        Label header, zodiacDescribe;
        ScrollView scrollView;
        public char[] charsToTrim = { '$', '*', ' ', '\'', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', ':', ';', '-', '+', '#', '!', '/', '¤', '%', '&', '(', ')', '=', '?', '`', '[', ']', '{', '}', '<', '>' };
        public Horoskop_Page()
        {
            // DatePicker
            zodiacDatePicker = new DatePicker
            {
                WidthRequest = 10,
                TextColor = Color.Violet
              
            };
            zodiacDatePicker.DateSelected += datePicker_DateSelected;

            chooseZodiacSign = new Picker
            {
                Title = "Выберите знак:",
                TextColor = Color.Violet,
                HorizontalTextAlignment = TextAlignment.Center

            };
            addingDataToPicker();

            chooseZodiacSign.SelectedIndexChanged += ChooseZodiacSign_SelectedIndexChanged;


            zodiacImage = new Image
            {
                Source = ""
            };

            zodiacDescribe = new Label
            {
                Text = "Чтобы найти информацию, выберите день или выполните поиск по знаку зодиака.",
                TextColor = Color.Violet,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            zodiacEntry = new Entry
            {
                Placeholder = "Поиск знака Зодиака:",
                
                WidthRequest = 10,
                MaxLength = 10,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                
                Keyboard = Keyboard.Text,
                ReturnType = ReturnType.Search,
                TextColor = Color.Violet,
            };
            zodiacEntry.Completed += Entry_Completed;

            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            grid.Children.Add
                (
                    header = new Label
                    {
                        Text = "Знаки Зодиака",
                        TextColor = Color.Gold,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    }, 0, 0 // column, row
                ); ;
            Grid.SetColumnSpan(header, 2);

            grid.Children.Add
                (
                    zodiacImage, 1, 1 // column, row
                );
            Grid.SetRowSpan(zodiacImage, 3);

            // 2 row
            grid.Children.Add
                (
                    zodiacDatePicker, 0, 1 // column, row
                );

            // 3 row
            grid.Children.Add
                (
                    zodiacEntry, 0, 2 // column, row
                );

            // 4 row
            grid.Children.Add
                (
                    chooseZodiacSign, 0, 3 // column, row
                );

            // 5 row
            grid.Children.Add
                (
                    scrollView = new ScrollView { Content = zodiacDescribe }, 0, 4 // column, row
                );
            Grid.SetColumnSpan(scrollView, 2);

            Content = grid;
        }

        private void ChooseZodiacSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            zodiacEntry.Text = chooseZodiacSign.SelectedItem.ToString();
            zodiacEntry.TextColor = Color.Violet;
            zodiacEntry.HorizontalTextAlignment = TextAlignment.Center;
            Entry_Completed(sender, e);
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string zodiacEntryText = zodiacEntry.Text.ToLower().Trim(charsToTrim);

            if (zodiacEntryText == "овен")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 04, 14);
            }
            else if (zodiacEntryText == "телец")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 05, 15);
            }
            else if (zodiacEntryText == "близнецы")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 06, 15);
            }
            else if (zodiacEntryText == "рак")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 07, 17);
            }
            else if (zodiacEntryText == "лев")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 08, 17);
            }
            else if (zodiacEntryText == "дева")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 09, 17);
            }
            else if (zodiacEntryText == "весы")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 10, 18);
            }
            else if (zodiacEntryText == "скорпион")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 11, 17);
            }
            else if (zodiacEntryText == "стрелец")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 12, 16);
            }
            else if (zodiacEntryText == "козерог")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 01, 15);
            }
            else if (zodiacEntryText == "водолей")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 02, 13);
            }
            else if (zodiacEntryText == "рыбы")
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 03, 15);
            }
            else
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                noZodiac();
            }

            header.Text = "Твой выбор: " + zodiacEntryText;
        }

        

        private void addingDataToPicker()
        {
            chooseZodiacSign.Items.Add("Овен");
            chooseZodiacSign.Items.Add("Телец");
            chooseZodiacSign.Items.Add("Близнецы");
            chooseZodiacSign.Items.Add("Рак");
            chooseZodiacSign.Items.Add("Лев");
            chooseZodiacSign.Items.Add("Дева");
            chooseZodiacSign.Items.Add("Весы");
            chooseZodiacSign.Items.Add("Скорпион");
            chooseZodiacSign.Items.Add("Стрелец");
            chooseZodiacSign.Items.Add("Козерог");
            chooseZodiacSign.Items.Add("Водолей");
            chooseZodiacSign.Items.Add("Рыбы");
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            header.Text = "Выбранная дата: " + e.NewDate.ToString("M");
            var month = e.NewDate.Month;
            var day = e.NewDate.Day;
            if (month == 3 && day >= 21 || month == 4 && day <= 20)
            {
                ovenZodiac();
            }
            else if (month == 4 && day >= 21 || month == 5 && day <= 20)
            {
                teletsZodiac();
            }
            else if (month == 5 && day >= 21 || month == 6 && day <= 20)
            {
                bliznetsyZodiac();
            }
            else if (month == 6 && day >= 21 || month == 7 && day <= 22)
            {
                rakZodiac();
            }
            else if (month == 7 && day >= 23 || month == 8 && day <= 22)
            {
                levZodiac();
            }
            else if (month == 8 && day >= 23 || month == 9 && day <= 22)
            {
                devaZodiac();
            }
            else if (month == 9 && day >= 23 || month == 10 && day <= 22)
            {
                vesyZodiac();
            }
            else if (month == 10 && day >= 23 || month == 11 && day <= 21)
            {
                skorpionZodiac();
            }
            else if (month == 11 && day >= 22 || month == 12 && day <= 21)
            {
                streletsZodiac();
            }
            else if (month == 12 && day >= 22 || month == 1 && day <= 19)
            {
                kozerogZodiac();
            }
            else if (month == 1 && day >= 20 || month == 2 && day <= 18)
            {
                vodoleiZodiac();
            }
            else if (month == 2 && day >= 19 || month == 3 && day <= 20)
            {
                rybyZodiac();
            }
            else
            {
                noZodiac();
            }
        }

        

        private void noZodiac()
        {
            zodiacEntry.Text = "";
            zodiacImage.Source = "blank.jpg";
            zodiacDescribe.Text = "Данные отсутствуют";
            zodiacDescribe.HorizontalTextAlignment = TextAlignment.Center;
            zodiacDescribe.TextColor = Color.Red;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
        }

        private void vesyZodiac()
        {
            zodiacEntry.Text = "Весы";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "vesy.jpg";
            zodiacDescribe.Text = "Весы - дипломатичный, артистичный, интеллигентный. " +
                "Единственный неодушевленный символ в зодиакальном круге, Весы являются вторым знаком стихии Воздуха. " +
                "Отличительной чертой представителей этого знака является стремление к гармонии во всем. " +
                "Чувствительные к прекрасному, прирожденные дипломаты, обладающие стойкостью духа и несгибаемой волей к победе в любом соперничестве, " +
                "Весы часто выступают в роли судей, а также юристов на всех уровнях. " +
                "Постоянство, надежность и созидательная сила — лучшие качества этого знака.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 6;
        }

        private void vodoleiZodiac()
        {
            zodiacEntry.Text = "Водолей";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "vodolei.jpg";
            zodiacDescribe.Text = "Водолей - одаренный воображением, идеалистический, интуитивный. " +
                "Знак фиксированного креста стихии Воздуха — Водолей изменчив по натуре, но не любит перемены, полон противоречий." +
                "Яркий индивидуалист, Водолей склонен к перепадам настроения, " +
                "то элегантен, то неряшлив, страдает отсутствием самодисциплины, решителен и обладает ярким темпераментом. " +
                "Не выносит рутины и скучных обязанностей. Независимость — как главное условие деятельности.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 10;
        }

        private void kozerogZodiac()
        {
            zodiacEntry.Text = "Козерог";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "kozerog.jpg";
            zodiacDescribe.Text = "Козерог - дотошный, умный, деятельный. " +
                "Знак Земной стихии, Козерог обладает даром не терять из виду главную цель и долго жить. " +
                "Целеустремленность, стойкость в трудностях, ответственность — это сильные качества представителей этого знака. " +
                "Козерог не боится одиночества, готов переносить любые житейские трудности, преодолеть любые препятствия. " +
                "Свои глубокие чувства предпочитает никому не открывать, с трудом близко сходится с людьми и не любит терять дружеские связи. " +
                "Если Козерогом кто-то пренебрег, то никогда не прощает и не возвращается. " +
                "Основной целью типичного Козерога является достижение максимально высокого ранга относительно условий личного старта. ";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 9;
        }

        private void streletsZodiac()
        {
            zodiacEntry.Text = "Стрелец";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "strelets.jpg";
            zodiacDescribe.Text = "Стрелец - авантюрный, творческий, волевой." +
                "Стрелец — знак стихии Огня, обладает ярко выраженной харизмой лидера, стремится к образованию, энергичен и увлечен идеей изменить весь мир. " +
                "Всю жизнь Стрелец стремится к популярности, к высокой оценке своей работы и достижений со стороны близких людей. " +
                "Стрелец почти всегда добивается успеха хотя бы в одном из многочисленных видов своей деятельности. " +
                "У энергичного по натуре Стрельца обычно несколько специальностей, широкий спектр интересов и деловых связей. " +
                "Свой бизнес, участие в общественной жизни нередко сопровождаются преподавательской или политической деятельностью.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 8;
        }

        private void skorpionZodiac()
        {
            zodiacEntry.Text = "Скорпион";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "skorpion.jpg";
            zodiacDescribe.Text = "Скорпион - чарующий, страстный, независимый." +
                "Скорпион фиксированный знак стихии Воды. Скорпион обладает природным магнетизмом и сильным характером. " +
                "Выносливый, сдержанный в словах и эмоциях, Скорпион умеет хранить секреты и ценит верность. " +
                "Скорпион — это знак внутренних изменений, преодоления слабости, борьбы до победного конца. " +
                "Рожденный под этим знаком всю жизнь совершенствуется сам и стремится изменить мир к лучшему.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 7;
        }

        private void rybyZodiac()
        {
            zodiacEntry.Text = "Рыбы";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "ryby.jpg";
            zodiacDescribe.Text = "Рыбы - творческий, чувствительный, артистичный. " +
                "Рыбы закрывают зодиакальный круг, представляя собой знак стихии Воды. " +
                "Это мудрые и восприимчивые люди, отзывчивость которых часто приводит их к общению с манипуляторами. " +
                "Подверженность чужому влиянию, высочайшая среди знаков зодиака способность к адаптации в любой окружающей обстановке," +
                "стойкость перед житейскими трудностями отличает типичных Рыб." +
                "Хорошо развитая от природы интуиция позволяет Рыбам приспособиться к любому общественному порядку, быть своим в любой среде, " +
                "находить наилучшие выходы из затруднительных положений и устанавливать деловые связи с неизменной выгодой для себя.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 11;
        }

        private void devaZodiac()
        {
            zodiacEntry.Text = "Дева";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "deva.jpg";
            zodiacDescribe.Text = "Дева - элегантный, организованный, добрый." +
                "Дева — второй знак стихии Земли, олицетворяющий справедливость и чистоту. " +
                "Дева воплощает принцип порядка, победу разума над чувствами, умение видеть целое в деталях. " +
                "Дева больше других знаков зодиака стремится к совершенству во всем, учится всю жизнь, но также учит и других. " +
                "Стремление к лучшему заставляет Деву подмечать изъяны во всем, что ее окружает, что требует исправления.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 5;
        }

        private void levZodiac()
        {
            zodiacEntry.Text = "Лев";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "lev.jpg";
            zodiacDescribe.Text = "Лев - горделивый, самоуверенный. " +
                "Фиксированный знак стихии Огня, Лев обладает даром созидания и настойчивостью в достижении своих целей. " +
                "Это деятельный человек, стремящийся к успеху и популярности. " +
                "Сильная, чувствительная и любящая натура, часто попадает под влияние эмоций и чувств. Лев великодушен, решителен и храбр. " +
                "Самообладание и амбициозность являются сильными чертами этого знака. Не равнодушен к вниманию, лести и роскоши.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 4;
        }

        private void rakZodiac()
        {
            zodiacEntry.Text = "Рак";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "rak.jpg";
            zodiacDescribe.Text = "Рак - интуитивный, эмоциональный, умный, страстный. " +
                "Знак стихии Воды находится под покровительством ночного светила. " +
                "Управление Луны влияет на характер представителей этого знака, делая их ранимыми и чувствительными людьми.  " +
                "Луна и водная стихия знака дают Раку способность к эмпатии, возможность мгновенно угадывать мысли и чаяния других людей. " +
                "Это решительные и благородные люди, часто патриоты. Но если жизнь Рака была полна лишений и несправедливости с детства, то обладают коварством и харизмой гангстера. " +
                "Влияют на других людей, могут подчинить себе ради достижения общей цели или выживания. Жесткие и проницательные руководители.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 3;
        }

        private void bliznetsyZodiac()
        {
            zodiacEntry.Text = "Близнецы";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "bliznetsy.jpg";
            zodiacDescribe.Text = "Близнецы - любопытный, нежный, добрый. " +
                "Знак подвижного креста стихии Воздуха. Близнецы обладают сильным характером, энергичны, независимы и общительны." +
                "Коммуникабельны, с веселым характером и темпераментным любопытством. Близнецы легко устанавливают связи со множеством разноплановых людей. " +
                "Интересные эрудированные собеседники, темпераментные и неутомимые, Близнецы живут активной и насыщенной жизнью, легко приспосабливаются к любой обстановке.  " +
                "Обеспечивают связи и потоки информации между людьми.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 2;
        }

        private void teletsZodiac()
        {
            zodiacEntry.Text = "Телец";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "telets.jpg";
            zodiacDescribe.Text = "Телец - основательный, музыкальный, практичный. " +
                "Фиксированный знак стихии Земли, созидатель и гурман, Телец воплощает собой принцип любви к жизни и ее благам, а также имеет качества упорства и практичности. " +
                "Телец умеет и любит работать, терпеливо создает себе комфортные условия для жизни. Способен долго и терпеливо ждать созревания подходящих условий. " +
                "Терпение Тельца удивительно, ему трудно учиться чему-то новому и приспосабливаться к незнакомым условиям. " +
                "Очень восприимчив ко всему прекрасному, обладает сильной интуицией, склонен анализировать ситуацию, прежде, чем совершать поступки. Дар Тельца — воплощать красивые мечты в реальность.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 1;
        }

        private void ovenZodiac()
        {
            zodiacEntry.Text = "Овен";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "oven.jpg";
            zodiacDescribe.Text = "Овен - амбициозный, независимый, нетерпеливый. " +
                "Овен, знак стихии Огня, открывает новый зодиакальный цикл, относится  " +
                "к стихии Огня, обладает особенной харизмой (качеством) первооткрывателя, инициативой и целеустремленностью. " +
                "Даже обладающие спокойным темпераментом, Овны никогда не забывают про свои цели и, как правило, рано или поздно достигают желаемого. " +
                "Инициатива и активность представителей этого знака позволяет находить новые задачи, которые Овен ставит перед своими последователями.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 0;
        }
    }
}