﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace CustomRally
{
    [Activity(Label = "CreateRouteActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]

    internal class CreateRouteActivity : AppCompatActivity, IOnMapReadyCallback
    {
        public MapFragment _mapFragment;
        public GoogleMap _map;
        public Location _currentLocation;
        public LocationManager _locationManager;

        public void OnMapReady(GoogleMap map)
        {
            //_map = map;

            //if (_map != null)
            //{
            //    displayMap();
            //}

            _map = map;

            // Add a marker in Sydney, Australia, and move the camera.
            LatLng sydney = new LatLng(-34, 151);
            _map.AddMarker(new MarkerOptions().SetPosition(sydney).SetTitle("Marker in Sydney"));
            _map.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
        }

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.CreateRoutesMap);
                //Add the map fragment (the map itself) to the android layout
                _mapFragment = MapFragment.NewInstance();
                if (_mapFragment != null)
                {
                    GoogleMapOptions mapOptions = new GoogleMapOptions()
                        .InvokeMapType(GoogleMap.MapTypeSatellite)
                        .InvokeZoomControlsEnabled(false)
                        .InvokeCompassEnabled(true);

                    FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                    _mapFragment = MapFragment.NewInstance(mapOptions);
                    fragTx.Add(Resource.Id.map, _mapFragment, "map");
                    fragTx.Commit();
                }
                _mapFragment.GetMapAsync(this);
            }
            catch (Exception e)
            {
                //Give the user enough time to view the exception
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
                System.Threading.Thread.Sleep(20000);
                throw;
            }

        }

        /// <summary>
        /// The method responible for displaying the map to the activity
        /// </summary>
        protected void displayMap()
        {
            //Student student = Student.getStudent();
            //List<Course> courses = student.Courses;

            //Stream input = Assets.Open($"ETSU Overlay.kml");

            //Add the building layers to the map
            //KmlLayer etsuLayer = new KmlLayer(_map, input, this);
            List<MarkerOptions> allBuildings = new List<MarkerOptions>();

            //foreach (var item in courses)
            //{
            //    MarkerOptions buildingMarker = new MarkerOptions();
            //    switch (item.buildingName.ToLower())
            //    {
            //        case "nicks":
            //            buildingMarker.SetPosition(new LatLng(BuildingLocations.nicksLat, BuildingLocations.nicksLong));
            //            buildingMarker.SetTitle("Nicks Hall");
            //            allBuildings.Add(buildingMarker);

            //            break;

            //        case "gilbreath":
            //            buildingMarker.SetPosition(new LatLng(BuildingLocations.gilbreathLat, BuildingLocations.gilbreathLong));
            //            buildingMarker.SetTitle("Gilbreath Hall");
            //            allBuildings.Add(buildingMarker);
            //            break;

            //        case "roger stout":
            //            buildingMarker.SetPosition(new LatLng(BuildingLocations.rogerStoutLat, BuildingLocations.rogerStoutLong));
            //            buildingMarker.SetTitle("Roger Stout Hall");
            //            allBuildings.Add(buildingMarker);
            //            break;

            //        case "wilson wallis":
            //            buildingMarker.SetPosition(new LatLng(BuildingLocations.wilsonWallisLat, BuildingLocations.wilsonWallisLong));
            //            buildingMarker.SetTitle($"Wilson Wallis Hall");
            //            allBuildings.Add(buildingMarker);
            //            break;

            //        case "burleson":
            //            buildingMarker.SetPosition(new LatLng(BuildingLocations.burlesonLat, BuildingLocations.burlesonLong));
            //            buildingMarker.SetTitle("Burleson Hall");
            //            allBuildings.Add(buildingMarker);
            //            break;

            //        case "brown":
            //            buildingMarker.SetPosition(new LatLng(BuildingLocations.brownLat, BuildingLocations.brownLong));
            //            buildingMarker.SetTitle("Brown Hall");
            //            allBuildings.Add(buildingMarker);
            //            break;
            //    }
            //}

            //foreach (var item in allBuildings)
            //{
            //    _map.AddMarker(item);
            //}

            //input = Assets.Open($"{buildingName}.kml");
            //KmlLayer layer = new KmlLayer(_map, input, this);
            //bool temp = layer.IsLayerOnMap;

            //MarkerOptions buildingMarker = new MarkerOptions();
            //buildingMarker.SetPosition(new LatLng(BuildingLocations.nicksLat, BuildingLocations.nicksLong));
            //buildingMarker.SetTitle($"{courses[0].buildingName}");
            //allBuildings.Add(buildingMarker);


            //Get the devices last known location
            _locationManager = (LocationManager)GetSystemService(LocationService);
            //_currentLocation = _locationManager.GetLastKnownLocation(LocationManager.GpsProvider);

            //Set the default view for ETSU when the user opens the map
            LatLng location = new LatLng(BuildingLocations.nicksLat, BuildingLocations.nicksLong);
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(15);

            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);


            _map.MapType = GoogleMap.MapTypeNormal;
            _map.MyLocationEnabled = true;
            _map.SetIndoorEnabled(true);
            _map.BuildingsEnabled = true;
            _map.MoveCamera(cameraUpdate);
            MarkerOptions options = new MarkerOptions();
            options = options.SetPosition(new LatLng(0, 0)).SetTitle("Marker");
            _map.AddMarker(options);
        }


    }
    public class BuildingLocations
    {
        public const double nicksLat = 36.302322;
        public const double nicksLong = -82.367873;
        public const double brownLat = 36.302322;
        public const double brownLong = -82.367873;
        public const double gilbreathLat = 36.303417;
        public const double gilbreathLong = -82.368498;
        public const double wilsonWallisLat = 36.300966;
        public const double wilsonWallisLong = -82.370628;
        public const double rogerStoutLat = 36.303365;
        public const double rogerStoutLong = -82.366165;
        public const double burlesonLat = 36.303957;
        public const double burlesonLong = -82.369679;
    }
}