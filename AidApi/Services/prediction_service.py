from Services.model_loader import ModelLoader
from Utils.image_transformer import transform_image
import torch

class PredictionService:
    def __init__(self):
        self.model_loader = ModelLoader()
        self.model = self.model_loader.model
        self.device = self.model_loader.device 

    def predict(self, image_path):
        tensor = transform_image(image_path)
        tensor = tensor.to(self.device)
        output = self.model(tensor)
        _, predicted = torch.max(output.data, 1)
        classes = ['Abrasions', 'Bruises', 'Burns', 'Cut', 'Ingrown_nails', 'Laceration', 'Stab_wound']
        return classes[predicted.item()]