import os

# Get the directory of the current file
BASE_DIR = os.path.dirname(os.path.abspath(__file__))

# Create the full path
MODEL_PATH = os.path.join(BASE_DIR, "..", "Models", "model_wounds.pth")
