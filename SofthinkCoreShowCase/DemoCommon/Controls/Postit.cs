using SofthinkCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DemoCommon.Controls
{
    public class Postit : Control
    {
        static Postit()
        {
            Postit.DefaultStyleKeyProperty.OverrideMetadata(typeof(Postit), new FrameworkPropertyMetadata(typeof(Postit)));
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Postit), new PropertyMetadata("default", null, new CoerceValueCallback(CoerceText)));

        private static object CoerceText(DependencyObject obj,object value)
        {
            if (value == null)
                return null;

            var postit = obj as Postit;
            if(postit.ExpandText)
            {
                double w = postit.RenderSize.Width;
                var size = postit.GetValue(FontSizeProperty);
                int maxln = (int)((double)w / ((double)size/2.0));
                if (maxln < 1)
                    maxln = 1;
                string nwtext = "";
                int start = 0;
                string real_text = value as string;
                while (start < real_text.Length)
                {
                    string sub = real_text.Substring(start, (start + maxln < real_text.Length) ? maxln : real_text.Length - start);
                    if(sub.Length < maxln)
                    {
                        nwtext += sub + ((start + maxln >= real_text.Length) ? "" : "\n");
                        start += maxln;
                        continue;
                    }
                    int ind = LastIndexOfBreackable(sub);
                    if (ind != -1)
                    {
                        nwtext += sub.Substring(0, ind) + ((start + ind + 1 >= real_text.Length) ? "" : "\n");
                        start += ind + 1;
                    }
                    else
                    {
                        ind = LastIndexOfScriptioContinua(sub);
                        if(ind != -1 && ind > 0)
                        {
                            nwtext += sub.Substring(0, ind -1) + ((start + ind  >= real_text.Length) ? "" : "\n");
                            start += ind +1;
                        }
                        else
                        {
                            nwtext += sub + ((start + maxln >= real_text.Length) ? "" : "\n");
                            start += maxln;
                        }
                       
                    }
                }
                return nwtext;
            }

            return value;
        }

        private static int LastIndexOfBreackable(string st)
        {
            int i = st.Length - 1;
            while( i >= 0)
            {
                int ch = st[i];
                if ( ch == ' ' || ch =='-' || ch == '\t' )
                    return i;
                i--;
            }

            return -1;
        }

        private static int LastIndexOfScriptioContinua(string st)
        {
            int i = st.Length - 1;
            while (i >= 0)
            {
                int ch = st[i];
                if (UnicodeHelper.ISScriptioContinua(ch))
                    return i;
                i--;
            }

            return -1;
        }


        public bool ExpandText
        {
            get { return (bool)GetValue(ExpandTextProperty); }
            set { SetValue(ExpandTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExpandText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpandTextProperty =
            DependencyProperty.Register("ExpandText", typeof(bool), typeof(Postit), new PropertyMetadata(false, new PropertyChangedCallback(OnExpandTextChanged)));

        private static void OnExpandTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs arg)
        {
            obj.CoerceValue(TextProperty);
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            CoerceValue(TextProperty);
        }

        


    }
}
