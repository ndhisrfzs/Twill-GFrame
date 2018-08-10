﻿using System;

namespace GN
{
    public class MessageHandlerAttribute : Attribute
    {
        public AppType Type { get; }
        public MessageHandlerAttribute()
        {

        }
        public MessageHandlerAttribute(AppType appType)
        {
            this.Type = appType;
        }
    }
}
