using SpotiClone.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using Newtonsoft.Json;
using System.Windows.Controls;
using SpotiClone.MVVM.Model.DataBase;

namespace SpotiClone.MVVM.ViewModel
{
    internal class MainViewModel
    {
        public List<Track> Songs { get; set; }
        public ArtistModel ArtistInfo { get; set; }
 
        private DataBaseModel _context;

        private Track _selectedTrack;
        public Track SelectedTrack
        {
            get => _selectedTrack; 
            set
            {
                _selectedTrack = value;
            }
        }
        public MainViewModel()
        {
            

            _context = new();
          
            _context.SendRequest("https://api.spotify.com/v1/artists/7dH8w9flSy9w81ilr0xXWe/top-tracks?market=ES");
            Songs = _context.GetResponse<TrackModel>().Tracks.ToList();

            _context.SendRequest("https://api.spotify.com/v1/artists/7dH8w9flSy9w81ilr0xXWe");
            ArtistInfo = _context.GetResponse<ArtistModel>();


        }

    
    }
}
