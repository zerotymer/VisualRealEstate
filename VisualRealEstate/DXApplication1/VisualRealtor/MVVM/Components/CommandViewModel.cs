using DevExpress.Xpf.Bars;
using System.Collections.Generic;
using System.Windows.Input;
using VisualRealtor.MVVM.Base;

namespace VisualRealtor.MVVM.Components
{
    public class CommandViewModel : ViewModel
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICommand Command { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CommandViewModel> Commands { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BarItemDisplayMode DisplayMode { get; set; }
        /// <summary>
        /// ComboBox 여부
        /// </summary>
        public bool IsComboBox { get; set; }
        /// <summary>
        /// 동작 여부
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 구분선 여부
        /// </summary>
        public bool IsSeparator { get; set; }
        /// <summary>
        /// 하위메뉴 여부
        /// </summary>
        public bool IsSubItem { get; set; }
        /// <summary>
        /// 단축키
        /// </summary>
        public KeyGesture KeyGesture { get; set; }
        /// <summary>
        /// 소유자
        /// </summary>
        public WorkspaceViewModel Owner { get; private set; }
        #endregion
        public static CommandViewModel Separator { get => new CommandViewModel() { IsSeparator = true }; }

        /// <summary>
        /// 
        /// </summary>
        public CommandViewModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="subCommands"></param>
        public CommandViewModel(string displayName, List<CommandViewModel> subCommands)
            : this(displayName, null, null, subCommands)
        {
        }
        public CommandViewModel(string displayName, ICommand command = null)
            : this(displayName, null, command, null)
        {
        }
        public CommandViewModel(WorkspaceViewModel owner, ICommand command)
            : this(string.Empty, owner, command)
        {
        }
        private CommandViewModel(string displayName, WorkspaceViewModel owner = null, ICommand command = null, List<CommandViewModel> subCommands = null)
        {
            IsEnabled = true;
            Owner = owner;
            if (Owner != null)
            {
                DisplayName = Owner.DisplayName;
                Glyph = Owner.Glyph;
            }
            else DisplayName = displayName;
            Command = command;
            Commands = subCommands;
        }

    }
}


