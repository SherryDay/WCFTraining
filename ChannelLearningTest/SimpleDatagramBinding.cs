using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ChannelLearningTest
{
    public class SimpleDatagramBinding : Binding
    {
        private TransportBindingElement transportBindingElement;
        private BindingElementCollection bindingElementCollection;

        public SimpleDatagramBinding()
        {
            BindingElement[] bindingElements = new BindingElement[]
            {
                new TextMessageEncodingBindingElement(),
                new HttpTransportBindingElement()
            };
            bindingElementCollection = new BindingElementCollection(bindingElements);
            transportBindingElement = (TransportBindingElement)bindingElements[1];
        }

        public override string Scheme
        {
            get
            {
                return transportBindingElement.Scheme;
            }
        }

        public override BindingElementCollection CreateBindingElements()
        {
            return bindingElementCollection;
        }
    }
}
