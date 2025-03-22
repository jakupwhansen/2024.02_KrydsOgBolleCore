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
            myDNN.start("[9,9,9,9]", "0,0,0,0,1,0,0,0,0 {1,0,0,0,0,0,0,0,0}");
            myDNN.theNet.learningRate = 0.025;
            myDNN.theNet.activFunction = "sigmoid";
            myDNN.theNet.clipGradience = false;
            myDNN.visExtra = false;
            myDNN.theNet.weightCorrectionFormula = 0;
            myDNN.viseBiasNeuroner = true;
            myDNN.theNet.momentum = 0.0001;
        }
       
        public void DNN_Make_Predictions(List<double> indputDataInd)
        {
            //--------MAKE PREDICTION-----------------------------------------------------
            // List<double> indputData = new List<double>();
            //indputData.Add(1);
            //indputData.Add(1);
            myDNN.addInputData(indputDataInd);
            myDNN.knapForwardPropagate();
            Console.WriteLine("-----------PRINT OUTPUT 1 ------------");
            foreach (var item in myDNN.getOutput())
            {
                Console.WriteLine("Out is: " + item);
            }
        }       
        public void DNN_Export_Weights()
        {
            //-------EXPORT AND IMPORT MODEL-----------------------------------------------
            String export = myDNN.export();
            System.IO.File.WriteAllText(@"DNN_Weights.txt", export);          
        }
        public void DNN_Import_Weights()
        {
            try
            {
                String hentet = System.IO.File.ReadAllText(@"DNN_Weights.txt");
                myDNN.import(hentet);
            }
            catch
            (Exception ex)
            {
                Console.WriteLine("Ingen vægte fundet");
            }

        }
        public void DNN_Train_Again(string learningData, int numberOfiterations)
        {  
           // myDNN.getLearningData("0, 0 { 0 } 1, 0 { 1 } 0, 1 { 1 } 1, 1 { 1 }");
            myDNN.getLearningData(learningData);
            Console.WriteLine("-------------Train with New Learning Data----------------------");
            for (int i = 0; i < numberOfiterations; i++)
            {
                myDNN.TrainOneStep();
            }

        }
    }
}
