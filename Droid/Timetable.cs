﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltBeaconOrg.BoundBeacon;
using Android.App;
using Android.Bluetooth.LE;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BeaconTest.Droid
{
    [Activity(Label = "Lecturer")]
    public class Timetable : Activity
    {
        private BeaconManager beaconManager;
        public AdvertiseCallback advertiseCallback;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Timetable);

            base.OnCreate(savedInstanceState);

            // Create your application here

            Button genBtn1 = FindViewById<Button>(Resource.Id.genBtn1);

            genBtn1.Click += delegate
            {
                beaconManager = BeaconManager.GetInstanceForApplication(this);

                BeaconTransmitter bTransmitter = new BeaconTransmitter();
                bTransmitter.Transmit();

                AlertDialog.Builder ad = new AlertDialog.Builder(this);
                ad.SetTitle("Started transmission");
                ad.SetMessage("Your device is now transmitting as an iBeacon for this lesson");
                ad.SetNeutralButton("OK", delegate
                {
                    ad.Dispose();
                });
                ad.Show();
            };
        }
    }
}