using AU.Optime.Mobile.CustomControls;
using AU.Optime.Mobile.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace AU.Optime.Mobile.Droid.CustomRenderers {
      //To connect mobile layer and android layer for searchbar
      public class CustomSearchBarRenderer : SearchBarRenderer {
            //protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e) {
            //      base.OnElementChanged(e);

            //      CustomSearchBar searchBar = (CustomSearchBar)Element;

            //      if (searchBar != null) {
            //            if (searchBar.IsLine == false) {
            //                  Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            //            }

            //      }
            //}
            protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e) {
                  base.OnElementChanged(e);

                  if(Control != null) {
                        var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                        var plate = Control.FindViewById(plateId);
                        plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
                        //this.Control.SetBackgroundColor(Android.Graphics.Color.Argb(0, 0, 0, 0));
                  }
            }

      }
}