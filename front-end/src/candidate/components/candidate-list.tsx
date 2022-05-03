import { observer } from "mobx-react";
import { useEffect } from "react";
import { CandidateService } from "../candidate-service";
import { Candidate } from "../models/candidate";
import { CandidateFilter } from "./candidate-filter";
import { CandidateItem } from "./candidate-item";

import './candidate.css'

export const CandidateList = observer(() => {
    const candidates = CandidateService.State.candidates;

    useEffect(() => {
        CandidateService.GetCandidates()
            .catch((c) => {
                alert(c);
            });
    }, []);

    const onAccept = (candidate: Candidate) => {
        CandidateService.SetStatus(candidate.candidateId, true)
            .then(c => {
                candidate.status = 1;
                CandidateService.ReloadState();
            });
    };

    const onReject = (candidate: Candidate) => {
        CandidateService.SetStatus(candidate.candidateId, false)
            .then(c => {
                candidate.status = 2;
                CandidateService.ReloadState();
            });
    };

    return (
        <>
            <CandidateFilter />
            <div className="candidate-list">
                {
                    candidates.length > 0 &&
                    candidates.map(c => <CandidateItem onAccept={onAccept} onReject={onReject}
                        key={c.candidateId} candidate={c} />)
                }

                {
                    candidates.length == 0 &&
                    <>
                        <p>
                            No item has been loaded !
                        </p>
                    </>
                }
            </div>
        </>
    );
});