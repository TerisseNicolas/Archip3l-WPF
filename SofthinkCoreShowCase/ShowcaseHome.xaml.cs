using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using SofthinkCore.Devices;
using SofthinkCore.Gestures.Processor;
using SofthinkCore.UI.Physic;
using SofthinkCore.UI.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SofthinkCoreShowCase
{
    /// <summary>
    /// Interaction logic for ShowcaseHome.xaml
    /// </summary>
    public partial class ShowcaseHome : UserControl
    {

        public ShowcaseHome()
        {
            InitializeComponent();

            physic_wheel.Initialysed += physic_wheel_Initialysed;

        }

        void physic_wheel_Initialysed(object sender, EventArgs e)
        {

            var RectangleA2 = BodyFactory.CreateRectangle(physic_wheel.world, 999999f, 999999f, 1.0f);
            RectangleA2.BodyType = BodyType.Static;
            RectangleA2.Position = new Vector2(0f, 0f);
            RectangleA2.Rotation = 0f;
            RectangleA2.CollisionCategories = Category.None;

            var joint = new RevoluteJoint(physic_wheel.Body, RectangleA2, physic_wheel.physicWorld.UIToPhysic(wheel_cont, 
                new Point(wheel_cont.RenderSize.Width / 2.0, wheel_cont.RenderSize.Height / 2.0)), true) 
            { MotorEnabled = true, MotorSpeed = -0.2f , MaxMotorTorque = 10};
            physic_wheel.world.AddJoint(joint);
        }
  
        
    }
}
