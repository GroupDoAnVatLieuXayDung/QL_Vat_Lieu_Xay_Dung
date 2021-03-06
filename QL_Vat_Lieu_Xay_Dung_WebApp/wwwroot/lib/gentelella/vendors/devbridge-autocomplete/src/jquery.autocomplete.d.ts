
interface JQueryAutocompleteOptions {
    serviceUrl?: string;
    lookup?: AutocompleteSuggestion[];
    lookupFilter? (suggestion: AutocompleteSuggestion, query: string, queryLowercase: string): any;
    onSelect? (suggestion: AutocompleteSuggestion): void;
    minChars: number;
    maxHeight: number;
    deferRequestBy?: number;
    width?: number;
    params?: Object;
    formatResult? (suggestion: AutocompleteSuggestion, currentValue: string): string;
    delimiter?: any;
    zIndex?: number;
    type?: string;
    noCache?: any;
    onSearchStart? (query: string): void;
    onSearchComplete? (query: string): void;
    tabDisabled?: any;
    paramName?: string;
    transformResult? (response: any, originalQuery: string): AutocompleteSuggestion[];
    autoSelectFirst?: any;
    appendTo: any;
    dataType: string;
}

interface AutocompleteSuggestion {
    value: string;
    data: any;
}

interface AutocompleteInstance {
    setOptions(options: JQueryAutocompleteOptions): void;
    clear(): void;
    clearCache(): void;
    disable(): void;
    enable(): void;
    hide(): void;
    dispose(): void;
}
