﻿using System.Linq;
using Chinchilla.Integration.Features.Messages;
using NUnit.Framework;

namespace Chinchilla.Integration.Features
{
    [TestFixture]
    public class PublishFeature : WithApi
    {
        [Test]
        public void ShouldPublishMessageOnDefaultPublisher()
        {
            using (var bus = Depot.Connect("localhost/integration"))
            {
                bus.Publish(new HelloWorldMessage());
            }

            Assert.That(admin.Exchanges(IntegrationVHost).Any(e => e.Name == "HelloWorldMessage"));
        }

        [Test]
        public void ShouldCreatePublisher()
        {
            using (var bus = Depot.Connect("localhost/integration"))
            {
                using (var publisher = bus.OpenPublishChannel())
                {
                    publisher.Publish(new HelloWorldMessage());
                    Assert.That(publisher.NumPublishedMessages, Is.EqualTo(1));
                }
            }

            Assert.That(admin.Exchanges(IntegrationVHost).Any(e => e.Name == "HelloWorldMessage"));
        }

        [Test]
        public void ShouldPublishMultipleMessages()
        {
            using (var bus = Depot.Connect("localhost/integration"))
            {
                using (var publisher = bus.OpenPublishChannel())
                {
                    for (var i = 0; i < 100; ++i)
                    {
                        publisher.Publish(new HelloWorldMessage());
                    }

                    Assert.That(publisher.NumPublishedMessages, Is.EqualTo(100));
                }
            }
        }
    }
}
