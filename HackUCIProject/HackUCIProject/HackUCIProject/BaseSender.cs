using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackUCIProject
{
    public class BaseSender : BaseSprite, ITriggerable
    {
        protected bool _isTriggered;
        public bool IsTriggered
        {
            get { return _isTriggered; }
        }

        public event EventHandler Triggered;

        private ITriggerable _objectBeingTriggered;

        public ITriggerable ObjectBeingTriggered
        {
            get { return _objectBeingTriggered; }
            set { _objectBeingTriggered = value; }
        }

        public virtual void Trigger()
        {
            _objectBeingTriggered.Trigger();
            _isTriggered = !_isTriggered;
            Triggered(this, null);
        }

        private TriggerType _triggerType;

        public BaseSender(TriggerType triggerType):
            base()
        {
            _triggerType = triggerType;
        }

        public TriggerType TriggerType
        {
            get
            {
                return _triggerType;
            }
        }
    }
}
