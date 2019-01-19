using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace XAML_HelloWorld
{
	/// <summary>
	/// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPageDataClass MainPageData = new MainPageDataClass();

		public MainPage()
		{
			this.InitializeComponent();
		}
	}

	public class MainPageDataClass
	{
		public string Libretto { get; set; } = string.Empty;
		public string TitleLabel { get; set; } = "しゃべらせてみる？";
		public string ButtonLabel { get; set; } = "Speak!";


		public bool IsValidLibretto() => string.IsNullOrWhiteSpace(this.Libretto) ? false : true;

		public async void Button_Click(object sernder, RoutedEventArgs e)
		{
			if (e == null)
			{
				throw new ArgumentNullException(nameof(e));
			}

			if (!IsValidLibretto())
			{
				Libretto = "文章を 入れてよ！";
			}

			MediaElement mediaElement = new MediaElement();
			var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
			Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(Libretto);
			mediaElement.SetSource(stream, stream.ContentType);
			mediaElement.Play();
		}
	}
}
