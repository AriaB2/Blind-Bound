using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackUCIProject
{
    public class BaseSender : BaseSprite, ITriggerable
    {
        protected bool _triggered;
        public bool Triggered
        {
            get { return _triggered; }
        }

        private ITriggerable _objectBeingTriggered;

        public ITriggerable ObjectBeingTriggered
        {
            get { return _objectBeingTriggered; }
            set { _objectBeingTriggered = value; }
        }

        public virtual void Trigger()
        {
            _objectBeingTriggered.Trigger();
            _triggered = !_triggered;
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
