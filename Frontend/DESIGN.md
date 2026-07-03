---
name: Rhythmic Precision
colors:
  surface: '#f8f9f9'
  surface-dim: '#d9dada'
  surface-bright: '#f8f9f9'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#f3f4f4'
  surface-container: '#edeeee'
  surface-container-high: '#e7e8e8'
  surface-container-highest: '#e1e3e3'
  on-surface: '#191c1c'
  on-surface-variant: '#564337'
  inverse-surface: '#2e3131'
  inverse-on-surface: '#f0f1f1'
  outline: '#897365'
  outline-variant: '#dcc1b1'
  surface-tint: '#944a00'
  primary: '#944a00'
  on-primary: '#ffffff'
  primary-container: '#e67e22'
  on-primary-container: '#502600'
  inverse-primary: '#ffb783'
  secondary: '#49626c'
  on-secondary: '#ffffff'
  secondary-container: '#c9e4f0'
  on-secondary-container: '#4d6670'
  tertiary: '#4b6076'
  on-tertiary: '#ffffff'
  tertiary-container: '#869bb3'
  on-tertiary-container: '#1d3347'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#ffdcc5'
  primary-fixed-dim: '#ffb783'
  on-primary-fixed: '#301400'
  on-primary-fixed-variant: '#713700'
  secondary-fixed: '#cce7f2'
  secondary-fixed-dim: '#b0cbd6'
  on-secondary-fixed: '#031f27'
  on-secondary-fixed-variant: '#324a54'
  tertiary-fixed: '#cfe5ff'
  tertiary-fixed-dim: '#b3c9e2'
  on-tertiary-fixed: '#051d30'
  on-tertiary-fixed-variant: '#34495e'
  background: '#f8f9f9'
  on-background: '#191c1c'
  surface-variant: '#e1e3e3'
typography:
  display-lg:
    fontFamily: Hanken Grotesk
    fontSize: 36px
    fontWeight: '600'
    lineHeight: '1.2'
    letterSpacing: 0.05em
  headline-lg:
    fontFamily: Hanken Grotesk
    fontSize: 28px
    fontWeight: '500'
    lineHeight: '1.3'
  headline-md:
    fontFamily: Hanken Grotesk
    fontSize: 20px
    fontWeight: '500'
    lineHeight: '1.4'
  body-md:
    fontFamily: Hanken Grotesk
    fontSize: 16px
    fontWeight: '400'
    lineHeight: '1.6'
  label-caps:
    fontFamily: Hanken Grotesk
    fontSize: 12px
    fontWeight: '700'
    lineHeight: '1.2'
    letterSpacing: 0.1em
  label-sm:
    fontFamily: Hanken Grotesk
    fontSize: 13px
    fontWeight: '500'
    lineHeight: '1.2'
rounded:
  sm: 0.125rem
  DEFAULT: 0.25rem
  md: 0.375rem
  lg: 0.5rem
  xl: 0.75rem
  full: 9999px
spacing:
  sidebar-width: 240px
  header-height: 80px
  gutter: 24px
  card-padding: 20px
  margin-sm: 8px
  margin-md: 16px
  margin-lg: 32px
---

## Brand & Style

The design system is engineered for professional management within a creative educational environment. It balances technical utility with a modern, high-contrast aesthetic that reflects the discipline of music theory and percussion.

The visual style is a hybrid of **Modern Corporate** and **Minimalist Tonalism**. It uses deep, immersive background tones to create a focused "studio" atmosphere, contrasted with crisp white work areas for high legibility during administrative tasks. The emotional response is one of organized efficiency, professional reliability, and energetic focus, signaled by deliberate pops of vibrant orange against a sophisticated slate and teal-grey palette.

## Colors

The palette is strategically layered to define functional zones:

- **Primary (Vibrant Orange):** Reserved strictly for key actions, active status indicators, and critical highlights.
- **Secondary (Teal-Grey):** Used for header backgrounds and secondary navigation elements to provide a calm, transitional zone.
- **Tertiary (Deep Slate/Charcoal):** Applied to the primary sidebar and navigation menus to ground the interface and reduce visual noise.
- **Neutral (Crisp White/Light Grey):** The canvas for main content, ensuring maximum readability for schedules and data.
- **Semantic Colors:** Green is used for "Available" status, while orange doubles for "In Use" or "Sharing" contexts to maintain high visibility.

## Typography

The system utilizes **Hanken Grotesk** for its sharp, contemporary geometry and exceptional legibility at various weights.

- **Branding & Headings:** Use wide letter spacing and uppercase styling for primary section headers (e.g., "MODULE 1") to create an editorial feel.
- **Navigation:** Labels are semi-bold and medium-sized to ensure they stand out against dark backgrounds.
- **Status Labels:** Small, all-caps labels are used for technical metadata (e.g., "ROOM STATUS", "UPCOMING PUPILS") to provide structural hierarchy without cluttering the view.

## Layout & Spacing

This design system follows a **Fixed-Fluid Hybrid** grid model:

- **Sidebar:** A fixed-width (240px) vertical navigation bar on the far left.
- **Sub-Navigation/Status Rail:** A secondary fixed-width panel (300px) for contextual information.
- **Main Content:** A fluid central area that expands to fill remaining space, housing the primary work cards.
- **Utility Panel:** A right-aligned panel for inspector-level details and specific module actions.

The rhythm is governed by a 4px baseline grid, with 24px gutters providing significant "breathing room" between major functional zones.

## Elevation & Depth

Hierarchy is established through **Tonal Layering** rather than heavy shadows:

- **Base Level:** The deep charcoal sidebar sits at the lowest elevation.
- **Surface Level:** The main white content area appears flush but is distinguished by its high contrast.
- **Object Level:** Cards and input blocks use a very soft, 2px stroke or a subtle 4px blur shadow (5% opacity) to lift slightly from the background.
- **Active Overlay:** Elements like the "Current Session" card use a white background against the light grey workspace to draw immediate focus.

## Shapes

The shape language is professional and precise. A **Soft** (4px - 8px) corner radius is applied to cards, buttons, and input fields to balance the industrial nature of the color palette.

Status tags and small utility icons (like the "Share" button) utilize a slightly more pronounced rounding (8px) to make them feel more interactive and distinct from structural containers.

## Components

### Sidebar Navigation

Items feature a subtle background highlight on hover. The active state is indicated by a background shift and a vertical highlight bar or high-contrast text color.

### Content Cards

Cards are the primary container for data. They should feature a clean white background, a 1px light grey border, and consistent 24px internal padding.

### Status Indicators

- **Available:** Text-only, green (#2ECC71), uppercase, bold.
- **In Use:** Text-only, orange (#E67E22), uppercase, bold.
- **Tags:** Solid orange backgrounds for active sharing or high-priority metadata.

### Buttons & Inputs

- **Primary Action:** Solid orange with white text.
- **Secondary Action:** Ghost style with light grey borders and subtle icon integration.
- **Search:** Dark-themed inputs with thin borders and integrated icons, typically located in utility panels.

### List Items

Interactive lists (like pupil schedules) should use a subtle hover state change and thin dividers (1px, #EEEEEE) to separate entries without adding visual weight.
