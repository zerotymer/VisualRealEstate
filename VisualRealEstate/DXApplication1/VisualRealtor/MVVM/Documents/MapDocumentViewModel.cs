using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VisualRealtor.Contorols;

namespace VisualRealtor.MVVM.Documents
{
    public class MapDocumentViewModel : DocumentViewModel
    {

        // TODO: 문서개요
        // TODO: 메뉴
        // TODO: 탐색기
        #region SolutionExplorer

        #endregion


        public MapDocumentViewModel()
        {
            //Test
            SolutionExplorerItem item = new SolutionExplorerItem() { Name = "Test", Description = "NONO" };
            List<SolutionExplorerItem> list = new List<SolutionExplorerItem>() { item };
            this.SolutionExplorerItems = new ReadOnlyCollection<SolutionExplorerItem>(list);
        }
    }
}
