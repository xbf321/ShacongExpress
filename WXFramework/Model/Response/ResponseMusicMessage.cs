﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Model
{
    [XmlRoot("xml")]
    public class ResponseMusicMessage : ResponseMessage
    {
        public ResponseMusicMessage() { }
        public ResponseMusicMessage(RequestMessage request)
            : base(request)
        {
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Music; }
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MusicURL { get; set; }

        public string HQMusicUrl { get; set; }

        public string ThumbMediaId { get; set; }
    }
}
