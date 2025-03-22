using DNN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrydsOgBolleCore
{
    internal class DNN_Trainer
    {
        DeepNeuralNetwork myDNN;
        public void DNN_Setup()
        {
            //----------SETUP---------------------------------------------------------
            myDNN = new DeepNeuralNetwork();
            myDNN.start("[2,1]", "0, 0 { 0 } 1, 0 { 0 } 0, 1 { 0 } 1, 1 { 1 }");
            myDNN.theNet.learningRate = 0.25;
            myDNN.theNet.activFunction = "sigmoid";
            myDNN.theNet.clipGradience = false;
            myDNN.visExtra = false;
            myDNN.theNet.weightCorrectionFormula = 0;
            myDNN.viseBiasNeuroner = true;
            myDNN.theNet.momentum = 0.0001;
        }
        List<double> indputData = new List<double>();
        public void DNN_Make_Predictions()
        {
            //--------MAKE PREDICTION-----------------------------------------------------           
            indputData.Add(1);
            indputData.Add(1);
            myDNN.addInputData(indputData);
            myDNN.knapForwardPropagate();
            Console.WriteLine("-----------PRINT OUTPUT 1 ------------");
            foreach (var item in myDNN.getOutput())
            {
                Console.WriteLine("Out is: " + item);
            }
        }
        public void TrainDNN()
        {   
            //---------TRAIN--------------------------------------------------------------
            for (int i = 0; i < 1000; i++)
            {
                myDNN.TrainOneStep();
            }
            //--------MAKE PREDICTION-----------------------------------------------------
            indputData = new List<double>();
            indputData.Add(0);
            indputData.Add(0);
            myDNN.addInputData(indputData);
            myDNN.knapForwardPropagate();
            Console.WriteLine("-----------PRINT OUTPUT 2 ------------");
            foreach (var item in myDNN.getOutput())
            {
                Console.WriteLine("Out is: " + item);
            }
            //-------EXPORT AND IMPORT MODEL-----------------------------------------------
            String export = myDNN.export();
            System.IO.File.WriteAllText(@"WriteLines.txt", export);
            String hentet = System.IO.File.ReadAllText(@"WriteLines.txt");
            myDNN.import(hentet);
            //--------MAKE PREDICTION-----------------------------------------------------
            indputData = new List<double>();
            indputData.Add(0);
            indputData.Add(0);
            myDNN.addInputData(indputData);
            myDNN.knapForwardPropagate();
            Console.WriteLine("-----------PRINT OUTPUT 3 ------------");
            foreach (var item in myDNN.getOutput())
            {
                Console.WriteLine("Out is: " + item);
            }
        }
        public void DNN_Export_Weights()
        {
            //-------EXPORT AND IMPORT MODEL-----------------------------------------------
            String export = myDNN.export();
            System.IO.File.WriteAllText(@"WriteLines.txt", export);          
        }
        public void DNN_Import_Weights()
        {
            String hentet = System.IO.File.ReadAllText(@"WriteLines.txt");
            myDNN.import(hentet);
        }
        public void DNN_Train_Again()
        {
            String hentet = System.IO.File.ReadAllText(@"WriteLines.txt");
            DNN_Setup();
            myDNN.getLearningData("0, 0 { 0 } 1, 0 { 1 } 0, 1 { 1 } 1, 1 { 1 }");
            Console.WriteLine("-------------Train with New Learning Data----------------------");
            for (int i = 0; i < 1000; i++)
            {
                myDNN.TrainOneStep();
            }

        }
    }
}
