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

        private List<ITriggerable> _objectsBeingTriggered;

        public List<ITriggerable> ObjectsBeingTriggered
        {
            get { return _objectsBeingTriggered; }
            set { _objectsBeingTriggered = value; }
        }

        public virtual void Trigger()
        {
            foreach(ITriggerable objects in _objectsBeingTriggered)
            {
                objects.Trigger();
            }
            _isTriggered = !_isTriggered;
            Triggered(this, null);
        }

        private TriggerType _triggerType;

        public BaseSender(TriggerType triggerType):
            base()
        {
            _triggerType = triggerType;
            _objectsBeingTriggered = new List<ITriggerable>();
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
