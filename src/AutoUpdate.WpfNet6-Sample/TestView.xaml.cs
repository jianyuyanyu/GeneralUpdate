﻿using GeneralUpdate.Core.Pipelines;
using GeneralUpdate.Core.Pipelines.Context;
using GeneralUpdate.Core.Pipelines.Middleware;
using GeneralUpdate.Core.Pipelines.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoUpdate.WpfNet6_Sample
{
    /// <summary>
    /// TestView.xaml 的交互逻辑
    /// </summary>
    public partial class TestView : Window
    {
        public TestView()
        {
            InitializeComponent();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            //var setup = Config.Stage(new TestClass()).
            //    Stage(new TestClass2());
            //PipelineBuilder.Create<double>(setup);
            //await ConfigFactory.Instance.Scan();

            var context = new UpdateContext();
            IPipelineBuilder builder = new PipelineBuilder<UpdateContext>(context).
                UseMiddleware<MD5Middleware>().
                UseMiddleware<CompressMiddleware>().
                UseMiddleware<ConfigMiddleware>().
                UseMiddleware<PatchMiddleware>().
                Launch();
        }
    }
}
