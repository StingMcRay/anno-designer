﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnoDesigner.Core.DataStructures;
using AnnoDesigner.Core.Models;
using AnnoDesigner.Core.Presets.Models;
using AnnoDesigner.CustomEventArgs;

namespace AnnoDesigner.Models
{
    public interface IAnnoCanvas : IHotkeySource
    {
        event EventHandler<EventArgs> ColorsInLayoutUpdated;
        event Action<List<LayoutObject>> OnClipboardChanged;
        event EventHandler<UpdateStatisticsEventArgs> StatisticsUpdated;
        event Action<string> OnLoadedFileChanged;
        event Action<string> OnStatusMessageChanged;
        event Action<LayoutObject> OnCurrentObjectChanged;

        QuadTree<LayoutObject> PlacedObjects { get; set; }
        List<LayoutObject> SelectedObjects { get; set; }
        List<LayoutObject> ClipboardObjects { get; }
        BuildingPresets BuildingPresets { get; }
        Dictionary<string, IconImage> Icons { get; }
        bool RenderGrid { get; set; }
        bool RenderInfluences { get; set; }
        bool RenderTrueInfluenceRange { get; set; }

        bool RenderLabel { get; set; }
        bool RenderIcon { get; set; }
        string LoadedFile { get; set; }
        int GridSize { get; set; }

        void InvalidateVisual();
        void SetCurrentObject(LayoutObject obj);
        void ResetZoom();
        void Normalize();
        void Normalize(int border);
        void OpenFile(string filename, bool forceLoad = false);
    }
}
