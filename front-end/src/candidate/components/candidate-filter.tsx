import { Grid, NativeSelect } from "@mui/material";
import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { LoadTechs, State } from "../../technology/technology-service";
import { CandidateService } from "../candidate-service";

export const CandidateFilter = observer(() => {
    useEffect(() => {
        LoadTechs();
    },[]);

    const candidateState = CandidateService.State;
    const techs = State.technologies;

    const onChange = (key: string, value: any) => {
        candidateState.setFilter({ ...candidateState.filter, [key] : value });
        console.log(value)
    };

    return (
        <Grid container justifyContent="space-between">
            <Grid item>
                <span>Only pending</span> : <input type="checkbox"
                    onChange={(value) => onChange("OnlyPending", value.target.checked)} />
            </Grid>

            <Grid item>
                <span>Technology</span> :
                <NativeSelect onChange={(value) => onChange("TechnologyId", value.target.value)}>
                    <option value="">empty</option>
                    {techs.map(c => <option key={c.id} value={c.id}>{c.name}</option>)}
                </NativeSelect>

            </Grid>

            <Grid item>
                <span>Min Years Of Experience</span> : <input type="number"
                    onChange={(value) => onChange("MinYearsOfExperience", value.target.value)} />            </Grid>
        </Grid>
    );
});