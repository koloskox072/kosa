namespace MauiApp5
{
    class Ksiazka
    {
        public int id;
        public string title;
        public string author;
        public string genre;
        public string publicationYear;
        public int pages;
        public string publisher;
        
        public Ksiazka(int id, string title, string author, string genre, string publicationYear, int pages, string publisher)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.publicationYear = publicationYear;
            this.pages = pages;
            this.publisher = publisher;
        }
    }
    public partial class MainPage : ContentPage
    {
        List<Ksiazka> list = new List<Ksiazka>();
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
            czytajKsiazki();
        }
        public void czytajKsiazki()
        {
            LoadMauiAsset();
        }
        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("baza.csv");
            using var reader = new StreamReader(stream);
            string c = reader.ReadLine();
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');
                list.Add(new Ksiazka(int.Parse(data[0]), data[1], data[2], data[3], data[4], int.Parse(data[5]), data[6]));
            }
            var contents = reader.ReadToEnd();
        }
        public void Next(object sender, EventArgs e)
        {
            count++;
            if(count == list.Count) count = 0;
            lbl1.Text = list[count].id.ToString();
            lbl2.Text = list[count].title;
            lbl3.Text = list[count].author;
            lbl4.Text = list[count].genre;
            lbl5.Text = list[count].publicationYear;
            lbl6.Text = list[count].pages.ToString();
            lbl7.Text = list[count].publisher;
        }
        public void Prev(object sender, EventArgs e)
        {
            count--;
            if (count == -1) count = list.Count-1;
            lbl1.Text = list[count].id.ToString();
            lbl2.Text = list[count].title;
            lbl3.Text = list[count].author;
            lbl4.Text = list[count].genre;
            lbl5.Text = list[count].publicationYear;
            lbl6.Text = list[count].pages.ToString();
            lbl7.Text = list[count].publisher;
        }
    }
}
