﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Tool;
using me.luohuaming.Gacha.UI;
using System.IO;

namespace me.luohuaming.Gacha.Code
{
    public class Event_StartUp : ICQStartup
    {
        static CQStartupEventArgs cq;
        public void CQStartup(object sender, CQStartupEventArgs e)
        {
            CQSave.cq_start = e;
            if (!File.Exists($@"{e.CQApi.AppDirectory}装备卡\框\抽卡背景.png"))
            {
                e.CQLog.Warning("错误","数据包未安装，插件无法运行，请仔细阅读论坛插件说明安装数据包，之后重启酷Q");
            }
            else
            {
                if (!File.Exists($@"{e.CQApi.AppDirectory}data.db"))
                {
                    Event_GroupMessage.CreateDB($@"{e.CQApi.AppDirectory}data.db");
                    e.CQLog.WriteLine(Native.Sdk.Cqp.Enum.CQLogLevel.Info, "已创建数据库");
                }
                else
                {
                    Event_GroupMessage.CheckDB($@"{e.CQApi.AppDirectory}data.db",e);
                }
            }
            cq = e;
            CQSave.cq_start = e;
        }
    }
}
