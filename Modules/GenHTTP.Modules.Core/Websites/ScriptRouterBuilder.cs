﻿using System.Collections.Generic;
using System.Linq;

using GenHTTP.Api.Content;
using GenHTTP.Api.Content.Websites;

namespace GenHTTP.Modules.Core.Websites
{

    public class ScriptRouterBuilder : IHandlerBuilder<ScriptRouterBuilder>
    {
        private readonly List<Script> _Scripts = new List<Script>();

        private ITheme? _Theme;

        private readonly List<IConcernBuilder> _Concerns = new List<IConcernBuilder>();

        #region Functionality

        public ScriptRouterBuilder Add(string name, IResourceProvider provider, bool asynchronous = false)
        {
            _Scripts.Add(new Script(name, asynchronous, provider));
            return this;
        }

        public ScriptRouterBuilder Add(IConcernBuilder concern)
        {
            _Concerns.Add(concern);
            return this;
        }

        public ScriptRouterBuilder Theme(ITheme theme)
        {
            _Theme = theme;
            return this;
        }

        public IHandler Build(IHandler parent)
        {
            var scripts = (_Theme != null) ? _Theme.Scripts.Union(_Scripts) : _Scripts;

            return Concerns.Chain(parent, _Concerns, (p) => new ScriptRouter(p, scripts.ToList()));
        }

        #endregion

    }

}
