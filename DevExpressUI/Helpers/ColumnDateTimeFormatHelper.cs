using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;

namespace DevExpressUI.Helpers
{
    public static class ColumnDateTimeFormatHelper
    {
        public static void ColumnDateTimeFormatter(CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "OpenTime" || e.Column.FieldName == "CloseTime" || e.Column.FieldName == "LogDate")
            { 
                e.Column.DisplayFormat.FormatString = "d.MMM.yyyy hh:mm tt";
            }
        }
    }
}
