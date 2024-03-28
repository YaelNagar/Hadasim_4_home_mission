import { CoronaPatients } from "./CoronaPatients";
import { VaccineToMember } from "./VaccineToMember";

export class HMOMembers{
    constructor(public Id?: Number, public Identity?: Number, public FirstName?: String, public LastName?: String,
        public BirthDate?: Date, public Telephone?: String, public Phone?: String, public Address?: String,
        public ProfileImage?: String, public CoronaPatients?: Array<CoronaPatients>, public VaccineToMember?: Array<VaccineToMember>) 
    { }
}