import { action, observable } from "mobx";

import RequestBuilder from "../base/request-builder";
import { GetTechs } from "../technology/technology-service";
import { Candidate } from "./models/candidate";
import { CandidateFilterDto } from "./models/candidate-filter-dto";

export class CandidateService {
    @action
    public static async GetCandidates() {
        const filter = CandidateService.State.filter;
        let requestBuilder = new RequestBuilder("GET", "https://localhost:50001/api/",
            "Candidate").addQueryParam("OnlyPending", filter.OnlyPending);

        if (filter.MinYearsOfExperience)
            requestBuilder = requestBuilder
                .addQueryParam("MinYearsOfExperience", filter.MinYearsOfExperience);

        if (filter.TechnologyId)
            requestBuilder = requestBuilder
                .addQueryParam("TechnologyId", filter.TechnologyId);

        const result = await requestBuilder
            .GetResultAsync<Candidate[]>();

        CandidateService.State.candidates = [];
        CandidateService.State.candidates = result;
    }

    public static async SetStatus(id: string, isAccepted: boolean) {
        const requestBuilder = new RequestBuilder("POST", "https://localhost:50001/api/")
            .setUrl("Candidate/{id}/SetStatus", { id })
            .addQueryParam('isAccepted', isAccepted)
            ;

        await requestBuilder.ExcuteAsync();
    }

    public static ReloadState() {
        CandidateService.GetCandidates();
    }

    public static State = observable<IState>({
        candidates: [],
        filter: {
            OnlyPending: false
        },
        setFilter(filter) {
            this.filter = filter;
            this.candidates = [];

            CandidateService.ReloadState();
        }
    });
}

interface IState {
    candidates: Candidate[]
    filter: CandidateFilterDto

    setFilter(filter: CandidateFilterDto): void
}