using sort;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfSort
{
    public class WfpSortViewModel : ViewModel
    {
        BubbleSort<int> bubbleSort;
        ShakerSort<int> shakerSort;
        CombSort<int> combSort;
        InsertSort<int> insertSort;
        InsertSort<int> shellSort;
        SelectSort<int> selectSort;

        //const int Length = 2000;
        const int delay = 0;
        const int swopDelay = 0;

        private int _length = 2000;

        public int Length
        {
            get { return _length; }
            set { Set(ref _length, value); }
        }

        private ObservableCollection<int> _colBubble;
        public ObservableCollection<int> ColBubble
        {
            get { return _colBubble; }
            set { Set(ref _colBubble, value); }
        }
        private int _selectedBubble;
        public int SelectedBubble
        {
            get { return _selectedBubble; }
            set { Set(ref _selectedBubble, value); }
        }
        private string _bubbleVisibility = string.Empty;
        public string BubbleVisibility
        {
            get { return _bubbleVisibility; }
            set { Set(ref _bubbleVisibility, value); }
        }

        private ObservableCollection<int> _colShaker;
        public ObservableCollection<int> ColShaker
        {
            get { return _colShaker; }
            set { Set(ref _colShaker, value); }
        }
        private int _selectedShaker;
        public int SelectedShaker
        {
            get { return _selectedShaker; }
            set { Set(ref _selectedShaker, value); }
        }
        private string _shakerVisibility = string.Empty;
        public string ShakerVisibility
        {
            get { return _shakerVisibility; }
            set { Set(ref _shakerVisibility, value); }
        }

        private ObservableCollection<int> _colComb;
        public ObservableCollection<int> ColComb
        {
            get { return _colComb; }
            set { Set(ref _colComb, value); }
        }
        private int _selectedComb;
        public int SelectedComb
        {
            get { return _selectedComb; }
            set { Set(ref _selectedComb, value); }
        }
        private string _combVisibility = string.Empty;
        public string CombVisibility
        {
            get { return _combVisibility; }
            set { Set(ref _combVisibility, value); }
        }

        private ObservableCollection<int> _colInsert;
        public ObservableCollection<int> ColInsert
        {
            get { return _colInsert; }
            set { Set(ref _colInsert, value); }
        }
        private int _selectedInsert;
        public int SelectedInsert
        {
            get { return _selectedInsert; }
            set { Set(ref _selectedInsert, value); }
        }
        private string _insertVisibility = string.Empty;
        public string InsertVisibility
        {
            get { return _insertVisibility; }
            set { Set(ref _insertVisibility, value); }
        }

        private ObservableCollection<int> _colShell;
        public ObservableCollection<int> ColShell
        {
            get { return _colShell; }
            set { Set(ref _colShell, value); }
        }
        private int _selectedShell;
        public int SelectedShell
        {
            get { return _selectedShell; }
            set { Set(ref _selectedShell, value); }
        }
        private string _shellVisibility = string.Empty;
        public string ShellVisibility
        {
            get { return _shellVisibility; }
            set { Set(ref _shellVisibility, value); }
        }

        private ObservableCollection<int> _colSelect;
        public ObservableCollection<int> ColSelect
        {
            get { return _colSelect; }
            set { Set(ref _colSelect, value); }
        }
        private int _selectedSelect;
        public int SelectedSelect
        {
            get { return _selectedSelect; }
            set { Set(ref _selectedSelect, value); }
        }
        private string _selectVisibility = string.Empty;
        public string SelectVisibility
        {
            get { return _selectVisibility; }
            set { Set(ref _selectVisibility, value); }
        }


        public WfpSortViewModel()
        {
            GenCommand = new LambdaCommand(OnGenExecuted, CanGen);
            SortCommand = new LambdaCommand(OnSortExecuted, CanSort);
        }

        #region gen
        public ICommand GenCommand { get; }
        private bool CanGen(object p) => true;
        private void OnGenExecuted(object p)
        {
            bubbleSort = new BubbleSort<int>(Length);
            bubbleSort.SwopDelay = swopDelay;
            shakerSort = new ShakerSort<int>(Length);
            shakerSort.SwopDelay = swopDelay;
            combSort = new CombSort<int>(Length);
            combSort.SwopDelay = swopDelay;
            insertSort = new InsertSort<int>(Length);
            insertSort.SwopDelay = swopDelay;
            shellSort = new InsertSort<int>(Length);
            shellSort.SwopDelay = swopDelay;
            selectSort = new SelectSort<int>(Length);
            selectSort.SwopDelay = swopDelay;
            Random random = new();
            for (int i = 0; i < Length; i++)
            {
                selectSort.collection[i] = shellSort.collection[i] = insertSort.collection[i] = combSort.collection[i] = shakerSort.collection[i] = bubbleSort.collection[i] = random.Next(-2500, 5001);
            }
            ColBubble = new ObservableCollection<int>(bubbleSort.collection);
            BubbleVisibility = string.Empty;
            ColShaker = new ObservableCollection<int>(shakerSort.collection);
            ShakerVisibility = string.Empty;
            ColComb = new ObservableCollection<int>(combSort.collection);
            CombVisibility = string.Empty;
            ColInsert = new ObservableCollection<int>(insertSort.collection);
            InsertVisibility = string.Empty;
            ColShell = new ObservableCollection<int>(shellSort.collection);
            ShellVisibility = string.Empty;
            ColSelect = new ObservableCollection<int>(selectSort.collection);
            SelectVisibility = string.Empty;
        }
        #endregion

        #region sort
        public ICommand SortCommand { get; }
        private bool CanSort(object p) => true;
        private void OnSortExecuted(object p)
        {
            if (bubbleSort == null || shakerSort == null || combSort == null || insertSort == null || selectSort == null)
            {
                return;
            }
            bubbleSort.OnSwop += new EventHandler<int>(SaveColToWinBubble);
            bubbleSort.OnFinish += BubbleSort_OnFinish;
            shakerSort.OnSwop += new EventHandler<int>(SaveColToWinShaker);
            shakerSort.OnFinish += ShakerSort_OnFinish;
            combSort.OnSwop += new EventHandler<int>(SaveColToWinComb);
            combSort.OnFinish += CombSort_OnFinish;
            insertSort.OnSwop += new EventHandler<int>(SaveColToWinInsert);
            insertSort.OnFinish += InsertSort_OnFinish;
            shellSort.OnSwop += new EventHandler<int>(SaveColToWinShell);
            shellSort.OnFinish += ShellSort_OnFinish;
            selectSort.OnSwop += new EventHandler<int>(SaveColToWinSelect);
            selectSort.OnFinish += SelectSort_OnFinish;
            Task.Run(() => bubbleSort.Sort());
            Task.Run(() => shakerSort.Sort());
            Task.Run(() => combSort.Sort());
            Task.Run(() => insertSort.Sort());
            Task.Run(() => shellSort.ShellSort());
            Task.Run(() => selectSort.Sort());
        }
        #endregion

        private void SaveColToWinBubble(object? sender, int i)
        {
            SelectedBubble = i;
            Thread.Sleep(delay);
            ColBubble = new ObservableCollection<int>(bubbleSort.collection);
        }
        private void BubbleSort_OnFinish(object? sender, EventArgs e)
        {
            BubbleVisibility = "SORTED";
            ColBubble = new ObservableCollection<int>(bubbleSort.collection);
        }

        private void SaveColToWinShaker(object? sender, int i)
        {
            SelectedShaker = i;
            Thread.Sleep(delay);
            ColShaker = new ObservableCollection<int>(shakerSort.collection);
        }
        private void ShakerSort_OnFinish(object? sender, EventArgs e)
        {
            ShakerVisibility = "SORTED";
            ColShaker = new ObservableCollection<int>(shakerSort.collection);
        }

        private void SaveColToWinComb(object? sender, int i)
        {
            SelectedComb = i;
            Thread.Sleep(delay);
            ColComb = new ObservableCollection<int>(combSort.collection);
        }
        private void CombSort_OnFinish(object? sender, EventArgs e)
        {
            CombVisibility = "SORTED";
            ColComb = new ObservableCollection<int>(combSort.collection);
        }

        private void SaveColToWinInsert(object? sender, int i)
        {
            SelectedInsert = i;
            Thread.Sleep(delay);
            ColInsert = new ObservableCollection<int>(insertSort.collection);
        }
        private void InsertSort_OnFinish(object? sender, EventArgs e)
        {
            InsertVisibility = "SORTED";
            ColInsert = new ObservableCollection<int>(insertSort.collection);
        }

        private void SaveColToWinShell(object? sender, int i)
        {
            SelectedShell = i;
            Thread.Sleep(delay);
            ColShell = new ObservableCollection<int>(shellSort.collection);
        }
        private void ShellSort_OnFinish(object? sender, EventArgs e)
        {
            ShellVisibility = "SORTED";
            ColShell = new ObservableCollection<int>(shellSort.collection);
        }

        private void SaveColToWinSelect(object? sender, int i)
        {
            SelectedSelect = i;
            Thread.Sleep(delay);
            ColSelect = new ObservableCollection<int>(selectSort.collection);
        }
        private void SelectSort_OnFinish(object? sender, EventArgs e)
        {
            SelectVisibility = "SORTED";
            ColSelect = new ObservableCollection<int>(selectSort.collection);
        }
    }
}
