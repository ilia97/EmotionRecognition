# EmotionRecognition

## System Requirements
Windows 8 or higher.

## Installation
- Run setup.cmd
- Run run.cmd

Corgradulations! You're ready to start.

## Usage
Enter your name and group.

The process of emotion recognition divides into two independent processes: nuaral network training and image prediction. For those processes you can see two tabs at the top of the window: `Training` and `Prediction`.

On the `Training` tab you can create your own model based on the dataset you have chosen. You should select the neural network type, select the type of the dataset (csv file or image files from directory), enter the path to the dataset (path to csv file or path to your folder with images) and enter the path to an empty output folder. Image dataset folder should contain folders from the next list: anger, disgust, fear, happiness, sadness, surprise, calm. You don't need to have the full set of emotions, you can train your model on some subset.

On the `Prediction` tab you can predict the emotion on the image. To do that you have to select the folder containing trained model, select the photo you would like to predict emotion of and select emotions subset you would like to predict from. Please, be sure that emotions subset is equal to emotions subset that the model was trained at.

## Requirements to Dataset
You can find examples of datasets in **datasets** folder.
 
.csv file should be formatted in the next way: first column contains the number of emotion (anger - 0, disgust - 1, fear - 2, happiness - 3, sadness - 4, surprise - 5, calm - 6), second column contains pixels of 48x48 dimentioned grayscaled photo, third column contains information of wether the photo is training or test.

If you use predition on photos dataset, you should use grayscale photos of the same dimention. It is better to use 640x490 dimention. Here is the list of features that are used to separate photos on classes: mouth (right mouth corner, left mouth corner, top mouth edge, bottom mouth edge), nose (nose center edge), eyes (right eye corner, left eye corner, top eye edge, bottom eye edge), eyebrows (right eyebrow edge, left eyebrow edge, eyebrow center).

## Used Neural Networks
- [ConvolutionalNN](https://medium.com/technologymadeeasy/the-best-explanation-of-convolutional-neural-networks-on-the-internet-fbb8b1ad5df8) are currently considered the go-to neural networks for Image Classification, because they pick up on patterns in small parts of an image, such as the curve of an eyebrow. EmoPy's ConvolutionalNN is trained on still images.
- [TimeDelayConvNN](https://ieeexplore.ieee.org/document/7090979?part=1) uses temporal information as part of its training samples. Instead of using still images as training samples, it uses past images from a series for additional context. One training sample will contain n number of images from a series and its emotion label will be that of the most recent image. The idea is to capture the progression of a facial expression leading up to a peak emotion.
- [ConvolutionalLstmNN](https://skymind.ai/wiki/lstm#recurrent) is a convolutional and recurrent neural network hybrid. Convolutional NNs use kernels, or filters, to find patterns in smaller parts of an image. Recurrent NNs (RNNs) take into account previous training examples, similar to the Time-Delay Neural Network, for context. This model is able to both extract local data from images and use temporal context. The Time-Delay model and this model differ in how they use temporal context. The former only takes context from within video clips of a single face as shown in the figure above. The ConvolutionLstmNN is given still images that have no relation to each other. It looks for pattern differences between past image samples and the current sample as well as their labels. It isn’t necessary to have a progression of the same face, simply different faces to compare.
- [TransferLearningNN](https://www.analyticsvidhya.com/blog/2017/06/transfer-learning-the-art-of-fine-tuning-a-pre-trained-model/) uses a technique known as Transfer Learning, where pre-trained deep neural net models are used as starting points. The pre-trained models it uses are trained on images to classify objects. The model then retrains the pre-trained models using facial expression images with emotion classifications rather than object classifications. It adds a couple top layers to the original model to match the number of target emotions we want to classify and reruns the training algorithm with a set of facial expression images. It only uses still images, no temporal context.

## Additional links
- [Emotion recognition on Wiki](https://en.wikipedia.org/wiki/Emotion_recognition) - link to emotion recognition problem
- [EmoPy](https://github.com/thoughtworksarts/EmoPy) library that was used for generating models and recognizing images.
- [EmotionRecognition](https://github.com/ilia97/EmotionRecognition) - link to the solution for application UI.
