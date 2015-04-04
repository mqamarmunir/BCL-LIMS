// Copyright: Maxim Saplin 2010, 2011
// Under LGPL License

using System.Web.UI;

namespace Saplin.Controls
{
    public abstract class StateManagedComplexProperty : IStateManager
    {
        private bool isTrackingViewState;
        private StateBag viewState;
        
        protected virtual StateBag ViewState
        {
            get
            {
                if (viewState == null)
                {
                    viewState = new StateBag(false);

                    if (isTrackingViewState)
                    {
                        ((IStateManager)viewState).TrackViewState();
                    }
                }
                return viewState;
            }
        }

        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return isTrackingViewState;
            }
        }

        void IStateManager.LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                ((IStateManager)ViewState).LoadViewState(savedState);
            }
        }

        object IStateManager.SaveViewState()
        {
            object savedState = null;

            if (viewState != null)
            {
                savedState =
                   ((IStateManager)viewState).SaveViewState();
            }
            return savedState;
        }

        void IStateManager.TrackViewState()
        {
            isTrackingViewState = true;

            if (viewState != null)
            {
                ((IStateManager)viewState).TrackViewState();
            }
        }

        public bool IsDirty
        {
            get
            {
                return ViewState.IsDirty();
            }
        }
    }
}

public static class StateBagExtensions
{
    public static bool IsDirty(this StateBag stateBag)
    {
        foreach (string key in stateBag.Keys)
        {
            if (stateBag.IsItemDirty(key)) return true;
        }

        return false;
    }
}

