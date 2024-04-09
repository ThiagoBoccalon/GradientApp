namespace GradientApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        private LinearGradientBrush RandomizeColourGradient()
        {
            var beginColour =
                System.Drawing.Color.FromArgb(
                    random.Next(0,255),
                    random.Next(0,255),
                    random.Next(0,255));

            var endColour =
                System.Drawing.Color.FromArgb(
                    random.Next(0,255),
                    random.Next(0,255),
                    random.Next(0,255));
            
            var numberOfColours = random.Next(4, 10);

            var colours =
                ColorControls
               .GetColours(beginColour, endColour, numberOfColours);

            var stops = new GradientStopCollection();
            var stopOffset = .0f;

            foreach(var colour in colours)
            {
                stops.Add(new GradientStop(Color.FromRgba(colour.Name),
                    stopOffset));


                stopOffset += .2f;
            }

            var gradient =
                new LinearGradientBrush(stops,
                new Point(0, 0),
                new Point(1, 1));

            return gradient;
        }

        private void ButtonGenerateNewGradientColour(object sender, EventArgs e)
        {
            background.Background = RandomizeColourGradient();
        }
    }

}
