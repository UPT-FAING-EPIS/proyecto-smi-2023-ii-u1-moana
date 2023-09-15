from fastapi import APIRouter, UploadFile, HTTPException,File
from Services.prediction_service import PredictionService


router = APIRouter()

@router.post("/predict/")
async def predict_wound(file: UploadFile = File(...)):
    prediction_service = PredictionService()
    
    with open("temp_image.jpg", "wb") as buffer:
        buffer.write(file.file.read())
    
    try:
        prediction = prediction_service.predict("temp_image.jpg")
        return {"prediction": prediction}
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))
