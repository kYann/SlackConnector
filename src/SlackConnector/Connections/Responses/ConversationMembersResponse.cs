﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SlackConnector.Connections.Responses
{
    public class ConversationMembersResponse : CursoredResponse
    {
		public string[] Members { get; set; }
    }
}
