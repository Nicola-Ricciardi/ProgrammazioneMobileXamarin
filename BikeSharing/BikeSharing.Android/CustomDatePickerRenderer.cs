using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;
using BikeSharing;
using BikeSharing.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Il tipo o il membro è obsoleto
[assembly: ExportRenderer(typeof(CustomDatePicker), target: typeof(CustomDatePickerRenderer))]
#pragma warning restore CS0612 // Il tipo o il membro è obsoleto
namespace BikeSharing.Droid
{
    [Obsolete]
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null)
            {

                return;
            }            
        }
        


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CustomDatePicker element = Element as CustomDatePicker;
            base.OnElementPropertyChanged(sender, e);            

            if (Control == null)
            {
                
                return;
            }
            
            UpdateBorders();
        }


        void UpdateBorders()
        {
            CustomDatePicker element = Element as CustomDatePicker;            

            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }
            else
            {
                Control.Text = element.Date.ToString("MM") + "/" + element.Date.ToString("dd") + "/" + element.Date.ToString("yyyy");
            }


            var view = (CustomDatePicker)Element;
            if (view.IsCurvedCornersEnabled)
            {
                var _gradientBackground = new GradientDrawable();
                _gradientBackground.SetShape(ShapeType.Rectangle);
                _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());
                this.Control.SetTextColor(Android.Graphics.Color.Black);

                if (((CustomDatePicker)this.Element).IsBorderErrorVisible)
                {
                    this.Control.SetTextColor(Android.Graphics.Color.Red);
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderErrorColor.ToAndroid());
                }
                else
                {
                    _gradientBackground.SetStroke(view.BorderWidth, view.LineColor.ToAndroid());
                }
                _gradientBackground.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));
                Control.SetBackground(_gradientBackground);
            }
            Control.SetPadding(
                (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
            
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}