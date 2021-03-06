﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TouchIDKeychain
{
	public partial class App : Application
	{
        public static CredentialsService Credentials { get; private set; }
        public static string AppName { get { return "TouchIDKeychainApp"; } }
        public App ()
		{
			InitializeComponent();

            Credentials = new CredentialsService();

			MainPage = new TouchIDKeychain.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
