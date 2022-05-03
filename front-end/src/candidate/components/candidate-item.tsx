import { Grid } from "@mui/material";
import { Candidate } from "../models/candidate";
import { CandidateExperience } from "../models/candidate-experience";

export const CandidateItem: React.FC<{
    candidate: Candidate
    onAccept(candidate: Candidate): void
    onReject(candidate: Candidate): void
}> = ({ candidate, onAccept, onReject }) => {
    return (
        <div className="candidate-item">
            <Grid container direction="column">
                <Grid item>
                    <Grid container justifyContent="space-between">
                        <Grid item>
                            <span>first name :</span> <span>{candidate.firstName}</span>
                        </Grid>

                        <Grid item>
                            <span>last name :</span> <span>{candidate.lastName}</span>
                        </Grid>
                    </Grid>
                </Grid>

                <Grid item>
                    <Grid container justifyContent="space-between">
                        <Grid item>
                            <span>email :</span> <span>{candidate.email}</span>
                        </Grid>

                        <Grid item>
                        </Grid>
                    </Grid>
                </Grid>

                {candidate.status == 0 &&
                    <Grid container justifyContent="space-between">
                        <Grid item>
                            <button onClick={() => onAccept(candidate)}>accept</button>
                        </Grid>

                        <Grid item>
                            <button onClick={() => onReject(candidate)}>reject</button>
                        </Grid>
                    </Grid>
                }


                {candidate.status != 0 &&
                    <>
                        <span>status : </span> {candidate.status == 1 ?
                            "accepted" : "rejected"}
                    </>}
            </Grid>

            <div className="candidate-experiences-wrapper">
                <b>experiences</b>
                {candidate.experiences.map(c => <CandidateExperienceItem
                    key={c.id} model={c} />)}
            </div>
        </div>
    );
};

const CandidateExperienceItem: React.FC<{ model: CandidateExperience }> = ({ model }) => {
    return (
        <Grid container justifyContent="space-between" className="candidate-experiences-item">
            <Grid item>
                {model.technologyName}
            </Grid>

            <Grid item>
                {model.yearsOfExperience}
            </Grid>
        </Grid>
    );
}