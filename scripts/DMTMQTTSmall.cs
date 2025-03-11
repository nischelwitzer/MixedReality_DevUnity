/*
The MIT License (MIT)
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;

// Examples for the M2MQTT library (https://github.com/eclipse/paho.mqtt.m2mqtt),

namespace M2MqttUnity.small
{

    public class DMTMQTTSmall : M2MqttUnityClient
    {

        private List<string> eventMessages = new List<string>();
        private int txCnt = 0;
        private int rxCnt = 0;

        private bool lampOn = false;
        private const string topicLampPower = "cmnd/tasmota_lavalamp_26C614/POWER";
        private const string topicLampStatus = "stat/tasmota_lavalamp_26C614/POWER";

        protected override void Start()
        {
            Debug.Log("MQTT small is ready.");

            brokerPort = 1883;
            // brokerAddress = "dmt.fh-joanneum.at";
            // mqttUserName = "dmt";
            //mqttPassword = "ss2021";
            isEncrypted = false;
            autoConnect = true;

            // InvokeRepeating("TogglePublish", 5, 2);
            Invoke("TestPublish", 5);

            base.Start();
        }

        public void TestPublish()
        {
            lampOn = !lampOn;
            string sendMsg = lampOn ? "OFF" : "ON";

            client.Publish(topicLampPower, System.Text.Encoding.UTF8.GetBytes(sendMsg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("##### Test message published: "+ topicLampPower+ " "+ sendMsg);
        }

        public void SendPublish(string sendMsg)
        {
            client.Publish(topicLampPower, System.Text.Encoding.UTF8.GetBytes(sendMsg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("##### MQTT Toggle published: " + topicLampPower + " " + sendMsg + " [" + (++txCnt) + "]");
        }

        public void TogglePublish()
        {
            lampOn = !lampOn;
            string sendMsg = lampOn ? "OFF" : "ON";

            client.Publish(topicLampPower, System.Text.Encoding.UTF8.GetBytes(sendMsg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("##### MQTT Toggle published: " + topicLampPower + " " + sendMsg + " [" + (++txCnt) +"]");
        }

        protected override void SubscribeTopics()
        {
            client.Subscribe(new string[] { topicLampStatus }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {

            string msg = System.Text.Encoding.UTF8.GetString(message);
            Debug.Log("MQTT Received: " + msg + " - " + (++rxCnt));
        }

        private void OnDestroy()
        {
            Disconnect();
        }

    }
}