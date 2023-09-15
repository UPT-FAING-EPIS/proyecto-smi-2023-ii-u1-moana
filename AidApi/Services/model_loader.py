import torch
from torchvision.models import resnet50
from Core.consts import MODEL_PATH
from Core.errors import ModelNotLoadedError

class ModelLoader:
    def __init__(self):
        self.device = torch.device("cuda:0" if torch.cuda.is_available() else "cpu")
        self.model = self.load_model()

    def load_model(self):
        model = resnet50(pretrained=True)
        model = model.to(self.device)
        num_ftrs = model.fc.in_features
        model.fc = torch.nn.Linear(num_ftrs, 7)
        try:
            model.load_state_dict(torch.load(MODEL_PATH, map_location=self.device))
            model.eval()
            return model
        except Exception:
            raise ModelNotLoadedError("No se pudo cargar el modelo correctamente.")

