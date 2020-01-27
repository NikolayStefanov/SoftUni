function personalBMI(patientName, patientAge, weightInKg, heightInCm) {
    let patient = {
        name: patientName,
        personalInfo: {
            age: patientAge,
            weight: weightInKg,
            height: heightInCm
        }
    };

    const patientHeightInM = heightInCm / 100;
    const squaredPatientHeight =  patientHeightInM ** 2;
    const patientBMI = weightInKg / squaredPatientHeight;

    patient["BMI"] = Math.round(patientBMI);
    patient["status"] = "";

    if (patientBMI < 18.5) {
        patient.status = "underweight";
    } else if(patientBMI < 25){
        patient.status = "normal";
    } else if(patientBMI < 30){
        patient.status = "overweight";
    } else {
        patient.status = "obese";
        patient["recommendation"] = "admission required";
    }

    return patient;
}


