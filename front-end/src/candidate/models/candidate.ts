import { CandidateExperience } from "./candidate-experience"

export interface Candidate {
    candidateId : string

    firstName : string
    lastName : string
    
    email : string
    status : number

    experiences : CandidateExperience[]
}