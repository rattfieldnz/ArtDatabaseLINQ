using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Art_Database_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Artist> artists;
        public List<Painting> paintings;

        private void Form1_Load(object sender, EventArgs e)
        {
            artists = new List<Artist>();
            artists.Add(new Artist { Country = "France", FirstName = "Camille", LastName = "Pissarro", YearOfBirth = 1830, YearOfDeath = 1903 });
            artists.Add(new Artist { Country = "France", FirstName = "Claude", LastName = "Monet", YearOfBirth = 1840, YearOfDeath = 1926 });
            artists.Add(new Artist { Country = "England", FirstName = "John", LastName = "Constable", YearOfBirth = 1776, YearOfDeath = 1837 });
            artists.Add(new Artist { Country = "Netherlands", FirstName = "Jan", LastName = "Vermeer", YearOfBirth = 1632, YearOfDeath = 1675 });
            artists.Add(new Artist { Country = "Italy", FirstName = "Sanzio", LastName = "Raphael", YearOfBirth = 1483, YearOfDeath = 1520 });
            artists.Add(new Artist { Country = "Spain", FirstName = "Pablo", LastName = "Picasso", YearOfBirth = 1881, YearOfDeath = 1973 });
            artists.Add(new Artist { Country = "Norway", FirstName = "Edvard", LastName = "Munch", YearOfBirth = 1863, YearOfDeath = 1944 });
            artists.Add(new Artist { Country = "Italy", FirstName = "Leonardo", LastName = "da Vinci", YearOfBirth = 1452, YearOfDeath = 1519 });
            artists.Add(new Artist { Country = "Italy", FirstName = "Sandro", LastName = "Botticelli", YearOfBirth = 1445, YearOfDeath = 1510 });
            artists.Add(new Artist { Country = "France", FirstName = "Henri", LastName = "Matisse", YearOfBirth = 1869, YearOfDeath = 1954 });
            artists.Add(new Artist { Country = "Netherlands", FirstName = "Piet", LastName = "Mondrian", YearOfBirth = 1872, YearOfDeath = 1944 });
            artists.Add(new Artist { Country = "United States", FirstName = "Jackson", LastName = "Pollock", YearOfBirth = 1912, YearOfDeath = 1956 });
            artists.Add(new Artist { Country = "Netherlands", FirstName = "Vincent", LastName = "van Gogh", YearOfBirth = 1853, YearOfDeath = 1890 });

            paintings = new List<Painting>();
            paintings.Add(new Painting { Artist = "van Gogh", Title = "The Starry Night", Method = "Oil on canvas", Year = 1889, Width = 72, Height = 92 });
            paintings.Add(new Painting { Artist = "van Gogh", Title = "Village Street in Auvers ", Method = "Oil on canvas", Year = 1890, Width = 73, Height = 92 });
            paintings.Add(new Painting { Artist = "Pissarro", Title = "Gelee Blanche", Method = "Oil on canvas", Year = 1873, Width = 65, Height = 93 });
            paintings.Add(new Painting { Artist = "Pissarro", Title = "Village Path", Method = "Oil on canvas", Year = 1875, Width = 72, Height = 92 });
            paintings.Add(new Painting { Artist = "Monet", Title = "Fishing Boats Leaving the Harbor, Le Havre ", Method = "Oil on canvas", Year = 1874, Width = 60, Height = 101 });
            paintings.Add(new Painting { Artist = "Monet", Title = "Water Lilies ", Method = "Oil on canvas", Year = 1906, Width = 88, Height = 93 });
            paintings.Add(new Painting { Artist = "Constable", Title = "The Leaping Horse", Method = "Oil on canvas", Year = 1825, Width = 142, Height = 187 });
            paintings.Add(new Painting { Artist = "Vermeer", Title = "Girl with a Pearl Earring", Method = "Oil on canvas", Year = 1665, Width = 45, Height = 40 });
            paintings.Add(new Painting { Artist = "Raphael", Title = "Madonna dell Granduca ", Method = "Oil on wood", Year = 1505, Width = 84, Height = 55 });
            paintings.Add(new Painting { Artist = "Raphael", Title = "St. George Fighting the Dragon ", Method = "Oil on wood", Year = 1825, Width = 28, Height = 21 });
            paintings.Add(new Painting { Artist = "Munch", Title = "The Scream", Method = "Tempera on paper", Year = 1893, Width = 91, Height = 74 });
            paintings.Add(new Painting { Artist = "da Vinci", Title = "The Last Supper", Method = "Tempera on plaster", Year = 1498, Width = 460, Height = 880 });
            paintings.Add(new Painting { Artist = "Botticelli", Title = "The Birth of Venus", Method = "Tempera on canvas", Year = 1485, Width = 173, Height = 280 });
            paintings.Add(new Painting { Artist = "Matisse", Title = "La Musique", Method = "Oil on canvas", Year = 1939, Width = 115, Height = 115 });
            paintings.Add(new Painting { Artist = "Mondrian", Title = "Composition with Red, Yellow and Blue", Method = "Oil on canvas", Year = 1821, Width = 40, Height = 35 });
            paintings.Add(new Painting { Artist = "Pollock", Title = "The Key", Method = "Oil on canvas", Year = 1946, Width = 84, Height = 213 });
            paintings.Add(new Painting { Artist = "Picasso", Title = "The Three Musicians", Method = "Oil on canvas", Year = 1921, Width = 200, Height = 222 });

            foreach(var artist in artists)
            {
                artistComboBox.Items.Add(artist.LastName);
            }



        }

        //------------------------------------------------------
        // btnAllPaintings
        //------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var allPaintings = from artist in artists
                               join painting in paintings
                               on artist.LastName equals painting.Artist
                               select new { artist.LastName, painting.Year, painting.Method, painting.Title };

            foreach (var artistPainting in allPaintings)
            {
                listBox1.Items.Add(artistPainting.LastName + "\t\t" +
                                   artistPainting.Year + "\t\t" +
                                   artistPainting.Method + "\t\t" +
                                   artistPainting.Title);
            }
        }


        //------------------------------------------------------
        // btnArtistsFromItaly
        //------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            IEnumerable<string> artistsFromItaly;

            artistsFromItaly = from artist in artists
                               where artist.Country == "Italy"
                               select artist.FirstName + " " +
                                      artist.LastName + "\t\t" +
                                      artist.YearOfBirth + "-" +
                                      artist.YearOfDeath + "\t\t" +
                                      artist.Country;

            foreach (string a in artistsFromItaly)
            {
                listBox1.Items.Add(a);
            }

        }

        //------------------------------------------------------
        // btnBefore1800
        //------------------------------------------------------
        private void btnBefore1800_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var allPaintings = from artist in artists
                               join painting in paintings
                               on artist.LastName equals painting.Artist
                               where painting.Year < 1800
                               select new { artist.LastName, painting.Year, painting.Method, painting.Title };

            foreach (var artistPainting in allPaintings)
            {
                listBox1.Items.Add(artistPainting.LastName + "\t\t" +
                                   artistPainting.Year + "\t\t" +
                                   artistPainting.Method + "\t\t" +
                                   artistPainting.Title);
            }
            
        }

        //------------------------------------------------------
        // btnOldest
        //------------------------------------------------------
        private void btnOldest_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var oldestPainting = (from artist in artists
                                  join painting in paintings
                                  on artist.LastName equals painting.Artist
                                  select new { artist.LastName, painting.Year, painting.Method, painting.Title }).OrderBy(p => p.Year).First();

            listBox1.Items.Add(oldestPainting.LastName + "\t\t" +
                                   oldestPainting.Year + "\t\t" +
                                   oldestPainting.Method + "\t\t" +
                                   oldestPainting.Title);
            
            
        }

        //------------------------------------------------------
        // byThisArtist
        //------------------------------------------------------
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var paintingsByArtist = from artist in artists
                                    join painting in paintings
                                    on artist.LastName equals painting.Artist
                                    where painting.Artist == (string)artistComboBox.SelectedItem
                                    select new { artist.LastName, painting.Year, painting.Method, painting.Title };

            foreach(var painting in paintingsByArtist)
            {
                listBox1.Items.Add(painting.LastName + "\t\t" +
                                       painting.Year + "\t\t" +
                                       painting.Method + "\t\t" +
                                       painting.Title);

            }
           
        }

        //------------------------------------------------------
        // btnNbyCountry
        //------------------------------------------------------
        private void btnNbyCountry_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var paintingsByCountry = from artist in artists
                                     join painting in paintings
                                     on artist.LastName equals painting.Artist
                                     orderby artist.Country
                                     group painting by artist.Country into countryCount
                                     orderby countryCount.Count()
                                     select new { Country = countryCount.Key, Count = countryCount.Count() };

            foreach (var pbc in paintingsByCountry)
            {
                if (pbc.Count < 2)
                {
                    listBox1.Items.Add(pbc.Count + " painting from " + pbc.Country);
                }
                else
                {
                    listBox1.Items.Add(pbc.Count + " paintings from " + pbc.Country);
                }
            }
        }

        //------------------------------------------------------
        // btnArtistGroupedByCountry
        //------------------------------------------------------
        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var artistsByCountry = artists.GroupBy(a => a.Country).OrderByDescending(a => a.Key).Reverse();

            foreach (var artist in artistsByCountry)
            {
                String countryName = artist.Key;

                listBox1.Items.Add(countryName + ":\n");

                foreach(var a in artists)
                {
                    if (a.Country == countryName)
                    {
                        listBox1.Items.Add("\t\t\t" + a.FirstName + " " + a.LastName);
                    }
                }
            }
        }

        //------------------------------------------------------
        // btnDutchPainters
        //------------------------------------------------------
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var dutchPainters = (from artist in artists
                                 join painting in paintings
                                 on artist.LastName equals painting.Artist
                                 where artist.Country == "Netherlands"
                                 select new { artist.LastName, painting.Year, painting.Method, painting.Title }).OrderByDescending(a => a.Year).Reverse();

            foreach (var artistPainting in dutchPainters)
            {
                listBox1.Items.Add(artistPainting.LastName + "\t\t" +
                                   artistPainting.Year + "\t\t" +
                                   artistPainting.Method + "\t\t" +
                                   artistPainting.Title);
            }
          
        }

        //------------------------------------------------------
        // btnJoinTables
        //------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var artistsCountries = (from artist in artists
                                    join painting in paintings
                                    on artist.LastName equals painting.Artist
                                    select new { artist.FirstName, artist.LastName, artist.Country, painting.Title, painting.Year }).OrderBy(a => a.LastName);

            foreach (var ac in artistsCountries)
            {
                listBox1.Items.Add(ac.FirstName + " " + ac.LastName + "\t\t" +
                                   ac.Country + "\t\t" +
                                   ac.Title);
            }
          
        }

        //------------------------------------------------------
        // btnFrenchOrItalian
        //------------------------------------------------------
        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var frenchItalianPaintings = (from artist in artists
                                          join painting in paintings
                                          on artist.LastName equals painting.Artist
                                          where artist.Country == "France" || artist.Country == "Italy"
                                          select new { artist.LastName, artist.Country, painting.Title })
                                                    .OrderByDescending(a => a.LastName).Reverse();

            foreach (var fip in frenchItalianPaintings)
            {
                listBox1.Items.Add(fip.LastName + "\t\t" + fip.Country + "\t\t" + fip.Title);
            }
          
        }

 
    }
}
