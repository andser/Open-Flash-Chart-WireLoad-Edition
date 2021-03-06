using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using JsonFx.Json;
using OpenFlashChart;

namespace OpenFlashChart
{
    public class OpenFlashChart
    {
        private Title title;
        private IList<ChartBase> elements;
        private XAxis x_axis;
        private YAxis y_axis;
        private YAxis y_axis_right;
        private Legend x_legend;
        private Legend y_legend;
        private string bgcolor;

        private ToolTip tooltip;

        public OpenFlashChart()
        {
            title = new Title("Chart Title");
            Elements = new List<ChartBase>();
            //x_axis = new XAxis();
            //y_axis= new YAxis();
            //y_axis_right = new YAxis();
        }
        [JsonProperty("title")]
        public Title Title
        {
            set { this.title = value; }
            get { return this.title; }
        }
        [JsonProperty("x_axis")]
        public XAxis X_Axis
        {
            get
            {
                if(x_axis==null)
                   x_axis= new XAxis();
                return this.x_axis;
            }
            set{ this.x_axis = value;}
        }
        [JsonProperty("y_axis")]
        public YAxis Y_Axis
        {
            get
            {
                if(y_axis==null)
                    y_axis= new YAxis();
                return this.y_axis;
            }
            set { this.y_axis = value; }
        }
        [JsonProperty("y_axis_right")]
        public YAxis Y_Axis_Right
        {
            get
            {
                return y_axis_right;
            }
            set { y_axis_right = value; }
        }
        [JsonProperty("elements")]
        public IList<ChartBase> Elements
        {
            get { return elements; }
            set { elements = value; }
        }
        public void AddElement(ChartBase chart)
        {
            this.elements.Add(chart);
            Y_Axis.SetRange(chart.GetMinValue(), chart.GetMaxValue());
           // X_Axis.SetRange(0,chart.GetValueCount());
            X_Axis.Steps = 1;
        }
        [JsonProperty("x_legend")]
        public Legend X_Legend
        {
            get { return x_legend; }
            set { x_legend = value; }
        }
        [JsonProperty("y_legend")]
        public Legend Y_Legend
        {
            get { return y_legend; }
            set { y_legend = value; }
        }
        [JsonProperty("bg_colour")]
        public string Bgcolor
        {
            get { return bgcolor; }
            set { bgcolor = value; }
        }
        [JsonProperty("tooltip")]
        public ToolTip Tooltip
        {
            get { return tooltip; }
            set { tooltip = value; }
        }

        public override string ToString()
        {
            StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
            using (JsonWriter writer = new JsonWriter(sw))
            {
                writer.SkipNullValue = true;
                writer.Write(this);
            }
            return sw.ToString();
        }
        public string ToPrettyString()
        {
            StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
            using (JsonWriter writer = new JsonWriter(sw))
            {
                writer.SkipNullValue = true;
                writer.PrettyPrint = true;
                writer.Write(this);
            }
            return sw.ToString();
        }
    }
}
