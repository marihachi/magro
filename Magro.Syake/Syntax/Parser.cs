﻿using Magro.Common.MiddleLevel;
using System.Collections.Generic;
using System.IO;

namespace Magro.Syake.Syntax
{
    internal partial class Parser
    {
        public ModuleDeclaration Parse(string moduleName, StreamReader reader)
        {
            var scan = new Scanner(reader);
            var statements = new List<IStatement>();

            while (!scan.Is(TokenKind.EOF))
            {
                statements.AddRange(ParseStatement(scan));
            }

            return new ModuleDeclaration()
            {
                Name = moduleName,
                Statements = statements,
            };
        }
    }
}