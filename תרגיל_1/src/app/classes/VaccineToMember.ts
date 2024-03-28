import { CoronaVaccines } from "./CoronaVaccines";

export class VaccineToMember{
    constructor(public IdMember?: Number, public IdVaccine?: Number, public CoronaVaccine?: CoronaVaccines) 
    { }
}